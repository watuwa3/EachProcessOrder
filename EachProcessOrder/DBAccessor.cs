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
        private static OracleConnection s_OracleConnection = null;
        private static MySqlConnection s_MySQLConnection = null;
        private static DBConfigData s_DBConfigData = null;

        // DB設定ファイル解析
        public static ProcessErrorType analyzeDbConfigFile(string configFileName)
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
        public static string GetSchema()
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

        public static string GetTargetDB()
        {
            return s_DBConfigData.TargetDB;
        }

        // DBオープン
        public static ProcessErrorType DBOpen()
        {
            DBConfigData s = s_DBConfigData;
            if (s.TargetDB == "Oracle")
            {
                if (s_OracleConnection != null && s_OracleConnection.State == ConnectionState.Open)
                {
                    return ProcessErrorType.None; 
                }
                return OracleOpen(s.UserID, s.DecPasswd, s.Protocol, s.Host, s.Port, s.ServiceName);
            }
            else
            {
                if (s_MySQLConnection != null && s_MySQLConnection.State == ConnectionState.Open)
                {
                    return ProcessErrorType.None;
                }
                return MySQLOpen(s.MyServer, s.MyDatabase, s.MyUser, s.DecPasswd, s.MyCharset);
            }
            return ProcessErrorType.DatabaseConnectionFailed;
        }

        // Oracleデータベースのオープン処理
        private static ProcessErrorType OracleOpen(string userid, string password, string protocol, string host, int port, string servicename)
        {
            // 挿入文字列と逐次的文字列を組み合わせた[$@]はやめた
            var datasource = $"(DESCRIPTION=(ADDRESS=(PROTOCOL={protocol})(HOST={host})(PORT={port}))(CONNECT_DATA=(SERVICE_NAME={servicename})))";
            var cnn = $"User Id={userid};Password={password};Data Source={datasource}";
            try
            {
                s_OracleConnection = new OracleConnection();
                s_OracleConnection.ConnectionString = cnn;
                s_OracleConnection.Open();
                return ProcessErrorType.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return ProcessErrorType.DatabaseConnectionFailed;
            }
        }

        // MySQLデータベースのオープン処理
        private static ProcessErrorType MySQLOpen(string server, string database, string uid, string pwd, string charset)
        {
            // MySQLへの接続情報
            try
            {
                // 挿入文字列と逐次的文字列を組み合わせた$@
                var cnn = $@"Server={server};Database={database};Uid={uid};Pwd={pwd};Charset={charset}";
                s_MySQLConnection = new MySqlConnection(cnn);
                s_MySQLConnection.Open();
                return ProcessErrorType.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return ProcessErrorType.DatabaseConnectionFailed;
            }
        }

        // DBクローズ
        public static ProcessErrorType DBClose()
        {
            if (s_DBConfigData.TargetDB == "Oracle")
            {
                return OracleClose();
            }
            else
            {
                return MySQLClose();
            }
            return ProcessErrorType.DatabaseConnectionFailed;
        }

        // Oracleデータベースのクローズ
        private static ProcessErrorType OracleClose()
        {
            try
            {
                if (s_OracleConnection != null)
                {
                    if (s_OracleConnection.State == ConnectionState.Open) { s_OracleConnection.Close(); }
                    s_OracleConnection = null;
                }
                return ProcessErrorType.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return ProcessErrorType.DatabaseConnectionFailed;
            }
        }

        // MySQLデータベースのクローズ
        private static ProcessErrorType MySQLClose()
        {
            try
            {
                if (s_MySQLConnection != null)
                {
                    if (s_MySQLConnection.State == ConnectionState.Open) { s_MySQLConnection.Close(); }
                    s_MySQLConnection = null;
                }
                return ProcessErrorType.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return ProcessErrorType.DatabaseConnectionFailed;
            }
        }

        // データ取得
        public static DataTable GetDataTable(string select, string from, string where, string orderby)
        {
            DataTable dt = new DataTable();
            try
            {
                if (s_DBConfigData.TargetDB == "Oracle")
                {
                    using (OracleDataReader reader = GetOracleData(select, from, where, orderby))
                    {
                        dt.Load(reader);
                    }
                }
                else
                {
                    using (MySqlDataAdapter myDa = GetMySQLData(select, from, where, orderby))
                    {
                        if (myDa != null) myDa.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;
        }

        private static MySqlDataAdapter GetMySQLData(string select, string from, string where, string orderby)
        {
            string sql = sqlString(select, from, where, orderby);
            // データ取得開始
            MySqlDataAdapter myDa = new MySqlDataAdapter(sql, s_MySQLConnection);
            return myDa;
        }

        // データ取得
        private static OracleDataReader GetOracleData(string select, string from, string where, string orderby)
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

        private static string sqlString(string select, string from, string where, string orderby)
        {
            // SQL組み立て
            string sql = "SELECT ";
            sql += (select == null || select == "") ? "*" : select;
            sql += " FROM " + from;
            sql += (where == null || where == "") ? "" : " WHERE " + where;
            sql += (orderby == null || orderby == "") ? "" : " ORDER BY " + orderby;
            return sql;
        }
    }
}
