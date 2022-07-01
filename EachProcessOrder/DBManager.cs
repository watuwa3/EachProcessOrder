using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EachProcessOrder
{
    public class DBManager
    {
        private static DBManager s_DBManager = new DBManager();
        private static DBAccessor s_DBAccessor;
        private static DBConfigData s_DBConfigData;

        private string s_SchemaName;

        private const string s_TableNameKM6010 = "KM6010";
        private const string s_TableNameKM6020 = "KM6020";
        private const string s_TableNameKM6030 = "KM6030";
        private const string s_TableNameKM6040 = "KM6040";
        private const string s_TableNameKM6050 = "KM6050";

        private const string s_TableNameM0200 = "M0200";
        private const string s_TableNameM0500 = "M0500";
        private const string s_TableNameM0600 = "M0600";

        // コンストラクタ
        private DBManager()
        {
            s_DBAccessor = new DBAccessor();

            // DB設定ファイル解析
            s_DBConfigData = s_DBAccessor.analyzeDbConfigFile();

            // スキーマ名設定
            s_SchemaName = null;
            if (s_DBConfigData.Schema != null)
            {
                s_SchemaName = s_DBConfigData.Schema + ".";
            }
        }

        // インスタンス取得
        public static DBManager GetInstance()
        {
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
                if (s_DBAccessor.OracleOpen(s_DBConfigData.User, s_DBConfigData.EncPasswd, s_DBConfigData.Protocol,
                    s_DBConfigData.Host, s_DBConfigData.Port, s_DBConfigData.ServiceName) == ProcessErrorType.DatabaseConnectionFailed)
                {
                    return ret;
                }

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

        // 得意先コード存在チェック
        public bool IsTkCdExsit(string tkCd)
        {
            if (tkCd == null) return false;
            string tableName = s_SchemaName + s_TableNameM0200;
            return IsDataExsit(tkCd, "TKCD", null, tableName, null);
        }

        // 部品番号存在チェック
        public bool IsCompHmCdExsit(string compHmCd)
        {
            if (compHmCd == null) return false;
            string tableName = s_SchemaName + s_TableNameM0500;
            return IsDataExsit(compHmCd, "HMCD", null, tableName, null);
        }

        // データ存在チェック
        private bool IsDataExsit(string targetValue, string targetColumn, string select, string from, string where)
        {
            bool ret = false;

            if (s_DBAccessor != null)
            {
                // Open
                {
                    // データ取得
                    OracleDataReader readDataReader = s_DBAccessor.GetOracleData(select, from, where);

                    // データ存在チェック
                    if (readDataReader != null)
                    {
                        while (readDataReader.Read())
                        {
                            if (targetValue == readDataReader[targetColumn].ToString())
                            {
                                ret = true;
                                break;
                            }
                        }
                    }
                }
            }

            return ret;
        }




        // ユーザID, パスワード確認
        public ProcessErrorType CheckUserInfoValid(string userName, string password)
        {
            // DBオープン
            if (s_DBAccessor.OracleOpen(s_DBConfigData.User, s_DBConfigData.EncPasswd, s_DBConfigData.Protocol,
                s_DBConfigData.Host, s_DBConfigData.Port, s_DBConfigData.ServiceName) != ProcessErrorType.None)
            {
                return ProcessErrorType.DatabaseConnectionFailed;
            }
            // ユーザーID確認
            string sqlWhere = "TANCD" + " = " + "'" + userName.ToUpper() + "'";
            //   -> M0010  - 担当者コード に存在しているIDか
            if (!IsDataExsit(userName, "TANCD", null, s_SchemaName + "M0010", sqlWhere))
            {
                s_DBAccessor.OracleClose();
                return ProcessErrorType.UserIdNotExist;
            }
            // パスワード確認
            //   -> M0010 - ユーザーID に紐づいているパスワードと一致しているか
            OracleDataReader readData = s_DBAccessor.GetOracleData(null, s_SchemaName + "M0010", sqlWhere);
            if (readData != null)
            {
                bool passwordExsit = false;
                while (readData.Read())
                {
                    if (password == readData["PASSWD"].ToString())
                    {
                        // パスワードが一致している
                        passwordExsit = true;
                        break;
                    }
                }
                if (!passwordExsit)
                {
                    // パスワードが一致していない
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

