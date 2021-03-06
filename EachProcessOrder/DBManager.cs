using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace EachProcessOrder
{
    public class DBManager
    {
        private static DBManager s_DBManager;
        private static string s_configFileName;
        private static string s_SchemaName;

        // コンストラクタ
        private DBManager()
        {
            // DB設定ファイル解析
            DBAccessor.analyzeDbConfigFile(s_configFileName);
            s_SchemaName = DBAccessor.GetSchema();
        }

        // インスタンス取得
        public static DBManager GetInstance(string configfilename)
        {
            s_configFileName = configfilename;
            s_DBManager = new DBManager();
            return s_DBManager;
        }

        // データベースオープン
        public static ProcessErrorType DBOpen() { return DBAccessor.DBOpen(); }

        // データベースクローズ
        public static ProcessErrorType DBClose() { return DBAccessor.DBClose(); }

        // 工程グループマスタ(M0400)の取得 (関係ありそうな工程Gコードのみ取得)
        public static void SetM0400(ref DataSet ds)
        {
            var where = "KTGCD in ('WL','MM','MP','BE')";
            DataTable dt = DBAccessor.GetDataTable("KTGCD, KTGSEQ, KTGNM, KTGRNM", "M0400", where,"KTGCD");
            ds.Tables.Add(dt);
            ds.Tables[ds.Tables.Count - 1].TableName = "M0400";
        }

        // 工程名称マスタ(M0410)の取得
        public static void SetM0410(ref DataSet ds)
        {
            DataTable dt = DBAccessor.GetDataTable("KTCD, KTNM, KTGCD, ODCD", "M0410", null, "KTCD");
            ds.Tables.Add(dt);
            ds.Tables[ds.Tables.Count - 1].TableName = "M0410";
        }

        // 手配データ(D0410)の取得 (先月の1日以降の全データを取得)
        public static DataTable GetD0410(DateTime _myToday)
        {
            var select = "ODRNO,KTSEQ,HMCD,KTCD,ODRQTY,ODCD,NEXTODCD,EDDT,EDTIM,ODRSTS,JIQTY,DATAKBN,RETKTCD";
            var baseday = new DateTime(_myToday.Year, _myToday.AddMonths(-1).Month, 1).ToString("yyyy/MM/dd");
            DataTable dt = DBAccessor.GetDataTable(select,"D0410", $"EDDT>'{baseday}'", "ODRNO");
            return dt;
        }

        public static string GetTargetDB(){ return DBAccessor.GetTargetDB(); }

        // ユーザID, パスワード確認
        public static ProcessErrorType CheckUserInfoValid(string username, string password)
        {
            string sqlwhere = $@"TANCD='{username.ToUpper()}'";
            using (DataTable dt = DBAccessor.GetDataTable(null, s_SchemaName + "M0010", sqlwhere, ""))
            {
                // ユーザーID確認 -> M0010 - 担当者コード に存在しているIDか
                if (dt.Rows.Count == 0) return ProcessErrorType.UserIdNotExist;
                
                // パスワード確認 -> M0010 - ユーザーID に紐づいているパスワードと一致しているかを調べる
                if (!dt.AsEnumerable().Any(row => row.Field<string>("PASSWD") == password))
                {
                    return ProcessErrorType.PasswordFaild;
                }
            }
            return ProcessErrorType.None;
        }
    }
}
