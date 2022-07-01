using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

using DecryptPassword;
using Oracle.ManagedDataAccess.Client;

namespace EachProcessOrder
{
    // データベース設定
    public class DBConfigData
    {
        public string User { get; set; }            // ユーザー ID
        public string EncPasswd { get; set; }       // パスワード
        public string Protocol { get; set; }        // プロトコル
        public string Host { get; set; }            // ホスト名 (IP アドレス)
        public int Port { get; set; }               // ポート番号
        public string ServiceName { get; set; }     // サービス名
        public string Schema { get; set; }          // スキーマ名
    }

    public class DBAccessor
    {
        private OracleConnection s_OracleConnection = null;

        // DB設定ファイル解析
        public DBConfigData analyzeDbConfigFile()
        {
            const string configFileName = "ConfigDB.xml";
            DBConfigData dBConfigData = null;
            
            try
            {
                // データベース情報の取得(xml)
                string dbxXmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
                if (File.Exists(dbxXmlFilePath))
                {
                    // XmlSerializerオブジェクトを作成
                    XmlSerializer serializer = new XmlSerializer(typeof(DBConfigData));

                    // 逆シリアライズ化
                    using (StreamReader sr = new StreamReader(dbxXmlFilePath, new System.Text.UTF8Encoding(false)))
                    {
                        // XMLファイルから読み込み、逆シリアル化する
                        dBConfigData = (DBConfigData)serializer.Deserialize(sr);
                        sr.Close();

                        // パスワードをデコード
                        if (dBConfigData.EncPasswd != null && dBConfigData.EncPasswd != "")
                        {
                            DecryptPasswordClass decryptPasswordClass = new DecryptPasswordClass();
                            string cryptographyPassword = dBConfigData.EncPasswd;
                            string decryptionPassword;
                            if (decryptPasswordClass.DecryptPassword(cryptographyPassword, out decryptionPassword))
                            {
                                // デコードしたパスワードを格納
                                dBConfigData.EncPasswd = decryptionPassword;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                dBConfigData = null;
            }

            return dBConfigData;
        }

        // DBオープン
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
        public OracleDataReader GetOracleData(string select, string from, string where)
        {
            OracleDataReader reader = null;
            // SQL組み立て
            string sqlString = "SELECT ";
            sqlString += (select == null) ? "*" : select;
            sqlString += " FROM " + from;
            sqlString += (where == null) ? "" : " WHERE " + where;

            // データ取得開始
            try
            {
                using (OracleCommand oracleCommand = new OracleCommand(sqlString))
                {
                    // データ読込み
                    oracleCommand.Connection = s_OracleConnection;
                    reader = oracleCommand.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return reader;
        }

    }

}
