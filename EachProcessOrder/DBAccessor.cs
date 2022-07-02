using System;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Windows.Forms;

using DecryptPassword;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;

namespace EachProcessOrder
{
    // データベース設定
    public class DBConfigData
    {
        // 共通情報
        public string TargetDB { get; set; }        // 対象データベース
        // Oralceへの接続情報
        public string UserID { get; set; }          // ユーザー ID
        public string Passwd { get; set; }          // パスワード
        public string Protocol { get; set; }        // プロトコル
        public string Host { get; set; }            // ホスト名 (IP アドレス)
        public int Port { get; set; }               // ポート番号
        public string ServiceName { get; set; }     // サービス名
        public string Schema { get; set; }          // スキーマ名
        // MySQLへの接続情報
        public string MyServer { get; set; }
        public string MyDatabase { get; set; }
        public string MyUser { get; set; }
        public string MyPass { get; set; }
        public string MyCharset { get; set; }
        public string DecPasswd { get; set; }       // 解除後パスワード
    }


    public class DBAccessor
    {
        private OracleConnection s_OracleConnection = null;
        private string s_MySQLConnection = null;
        private DBConfigData s_DBConfigData = null;

        // DB設定ファイル解析
        public ProcessErrorType analyzeDbConfigFile(ref string configFileName)
        {
            try
            {
                // データベース情報の取得(xml)
                // XmlSerializerオブジェクトを作成
                XmlSerializer serializer = new XmlSerializer(typeof(DBConfigData));

                // 逆シリアライズ化
                using (StreamReader sr = new StreamReader(configFileName, new System.Text.UTF8Encoding(false)))
                {
                    // XMLファイルから読み込み、逆シリアル化する
                    s_DBConfigData = (DBConfigData)serializer.Deserialize(sr);
                    sr.Close();

                    // パスワードをデコード
                    string pwd = "";
                    if (s_DBConfigData.TargetDB == "Oracle") pwd = s_DBConfigData.Passwd;
                    else pwd = s_DBConfigData.MyPass;
                    if (pwd != null && pwd != "")
                    {
                        DecryptPasswordClass decryptPasswordClass = new DecryptPasswordClass();
                        string cryptographyPassword = pwd;
                        string decryptionPassword;
                        if (decryptPasswordClass.DecryptPassword(cryptographyPassword, out decryptionPassword))
                        {
                            // デコードしたパスワードを格納
                            s_DBConfigData.DecPasswd = decryptionPassword;
                        }
                    }
                }
                return ProcessErrorType.None;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                s_DBConfigData = null;
                return ProcessErrorType.ConfigDbFileReadError;
            }

        }

        // スキーマ名設定
        public string GetSchema()
        {
            if (s_DBConfigData.TargetDB == "Oracle")
            {
                return s_DBConfigData.Schema + ".";
            }
            else
            {
                return s_DBConfigData.MyDatabase + ".";
            }
        }

        // DBオープン
        public ProcessErrorType Open()
        {
            if (s_DBConfigData.TargetDB == "Oracle")
            {
                return OracleOpen(s_DBConfigData.UserID, s_DBConfigData.DecPasswd, s_DBConfigData.Protocol,
                    s_DBConfigData.Host, s_DBConfigData.Port, s_DBConfigData.ServiceName);
            }
            else
            {
                return MySQLOpen(s_DBConfigData.MyServer, s_DBConfigData.MyDatabase, s_DBConfigData.MyUser,
                    s_DBConfigData.DecPasswd, s_DBConfigData.MyCharset);
            }
            return ProcessErrorType.DatabaseConnectionFailed;
        }

        // 
        public ProcessErrorType MySQLOpen(string server, string database, string uid, string pwd, string charset)
        {
            // MySQLへの接続情報
            s_MySQLConnection = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4}", server, database, uid, pwd, charset);
            return ProcessErrorType.None;
        }

        // 
        public ProcessErrorType OracleOpen(string userId, string password, string protocol, string host, int port, string serviceName)
        {
            string dataSource =
                "(DESCRIPTION=" +
                "(ADDRESS=" +
                "(PROTOCOL=" + protocol + ")" +
                "(HOST=" + host + ")" +
                "(PORT=" + port + ")" + ")" +
                "(CONNECT_DATA=" + "(SERVICE_NAME=" + serviceName + ")" + ")" +
                ")";
            try
            {
                s_OracleConnection = new OracleConnection();
                if (s_OracleConnection != null)
                {
                    string connectString = "User Id=" + userId + "; "
                                    + "Password=" + password + "; "
                                    + "Data Source=" + dataSource;
                    s_OracleConnection.ConnectionString = connectString;

                    s_OracleConnection.Open();
                    return ProcessErrorType.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return ProcessErrorType.DatabaseConnectionFailed;
        }

        // DBクローズ
        public bool OracleClose()
        {
            // クローズ
            try
            {
                if (s_OracleConnection != null)
                {
                    s_OracleConnection.Close();
                    s_OracleConnection = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return false;
        }

        // データ取得
        public DataTable GetDataTable(string select, string from, string where, string orderby)
        {
            DataTable dt = new DataTable();
            try
            {
                if (s_DBConfigData.TargetDB == "Oracle")
                {
                    OracleDataReader reader = GetOracleData(select, from, where, orderby);
                    dt.Load(reader);
                }
                else
                {
                    MySqlDataAdapter myDa = GetMySQLData(select, from, where, orderby);
                    myDa.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;
        }

        private MySqlDataAdapter GetMySQLData(string select, string from, string where, string orderby)
        {
            string sql = sqlString(select, from, where, orderby);
            // データ取得開始
            MySqlDataAdapter myDa = new MySqlDataAdapter(sql, s_MySQLConnection);
            return myDa;
        }

        // データ取得
        private OracleDataReader GetOracleData(string select, string from, string where, string orderby)
        {
            string sql = sqlString(select, from, where, orderby);
            // データ取得開始
            try
            {
                using (OracleCommand oracleCommand = new OracleCommand(sql))
                {
                    // データ読込み
                    oracleCommand.Connection = s_OracleConnection;
                    return oracleCommand.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }

        private string sqlString(string select, string from, string where, string orderby)
        {
            // SQL組み立て
            string sql = "SELECT ";
            sql += (select == null || select == "") ? "*" : select;
            sql += " FROM " + from;
            sql += (where == null || where == "") ? "" : " WHERE " + where;
            sql += (orderby == null || orderby == "") ? "" : " ORDER BY " + orderby;
            return sql;
        }

        // データ存在チェック
        public bool IsDataExsit(string targetValue, string targetColumn, string select, string from, string where)
        {
            DataTable dt = GetDataTable(select, from, where, "");
            var str = dt.Rows[0][targetColumn].ToString();
            if (str == targetValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
