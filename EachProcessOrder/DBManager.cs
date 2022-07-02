using System;
using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace EachProcessOrder
{
    public class DBManager
    {
        private static DBManager s_DBManager;
        private static DBAccessor s_DBAccessor;
        private static string s_configFileName;

        private const string s_TableNameKM6010 = "KM6010";
        private const string s_TableNameKM6020 = "KM6020";
        private const string s_TableNameKM6030 = "KM6030";
        private const string s_TableNameKM6040 = "KM6040";
        private const string s_TableNameKM6050 = "KM6050";

        private const string s_TableNameM0200 = "M0200";
        private const string s_TableNameM0500 = "M0500";
        private const string s_TableNameM0600 = "M0600";
        private string s_SchemaName;

        // コンストラクタ
        private DBManager()
        {
            // DB設定ファイル解析
            s_DBAccessor = new DBAccessor();
            s_DBAccessor.analyzeDbConfigFile(ref s_configFileName);
            s_SchemaName = s_DBAccessor.GetSchema();
        }

        // インスタンス取得
        public static DBManager GetInstance(string configFileName)
        {
            s_configFileName = configFileName;
            s_DBManager = new DBManager();
            return s_DBManager;
        }

        // 手配データ取得
        public bool MakeDataSet(ref DataSet ds)
        {

            bool ret = false;

            try
            {
                if (s_DBAccessor == null)
                {
                    return ret;
                }

                // DB設定ファイルが存在しない

                // Open

                // Close
                s_DBAccessor.OracleClose();
                ret = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                s_DBAccessor.OracleClose();
                ret = false;
            }

            return ret;
        }

        public ProcessErrorType DBOpen()
        {
            return s_DBAccessor.Open();
        }

        // 工程グループマスタ取得
        public void SetM0400(ref DataSet ds)
        {
            DataTable dt = s_DBAccessor.GetDataTable("", "M0400", "KTGCD in ('WL','MM','MP','BE')","KTGCD");
            ds.Tables.Add(dt);
            ds.Tables[ds.Tables.Count - 1].TableName = "M0400";
        }

        // 得意先コード存在チェック
        public bool IsTkCdExsit(string tkCd)
        {
            if (tkCd == null) return false;
            string tableName = s_SchemaName + s_TableNameM0200;
            return s_DBAccessor.IsDataExsit(tkCd, "TKCD", null, tableName, null);
        }

        // 部品番号存在チェック
        public bool IsCompHmCdExsit(string compHmCd)
        {
            if (compHmCd == null) return false;
            string tableName = s_SchemaName + s_TableNameM0500;
            return s_DBAccessor.IsDataExsit(compHmCd, "HMCD", null, tableName, null);
        }

        // ユーザID, パスワード確認
        public ProcessErrorType CheckUserInfoValid(string userName, string password)
        {
            // DBオープン
            if (s_DBAccessor.Open() != ProcessErrorType.None)
            {
                return ProcessErrorType.DatabaseConnectionFailed;
            }
            // ユーザーID確認
            string sqlWhere = "TANCD" + " = " + "'" + userName.ToUpper() + "'";
            //   -> M0010  - 担当者コード に存在しているIDか
            if (!s_DBAccessor.IsDataExsit(userName, "TANCD", null, s_SchemaName + "M0010", sqlWhere))
            {
                s_DBAccessor.OracleClose();
                return ProcessErrorType.UserIdNotExist;
            }
            // パスワード確認
            //   -> M0010 - ユーザーID に紐づいているパスワードと一致しているか
            DataTable dt = s_DBAccessor.GetDataTable(null, s_SchemaName + "M0010", sqlWhere, "");
            if (dt != null)
            {
                // パスワードが一致しているかを調べる
                if (dt.AsEnumerable().Any(n => n["PASSWD"] == password))
                {
                    s_DBAccessor.OracleClose();
                    return ProcessErrorType.PasswordNotExist;
                }
            }
            else
            {
                s_DBAccessor.OracleClose();
                return ProcessErrorType.PasswordNotExist;
            }
            // DB切断
            s_DBAccessor.OracleClose();
            return ProcessErrorType.None;
        }
    }
}

