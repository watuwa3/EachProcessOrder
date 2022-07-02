using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace EachProcessOrder
{
    using static Common;

    public partial class LoginWindow : Form
    {
        private string s_configFileName;
        private DBManager s_DBManager;

        public LoginWindow()
        {
            InitializeComponent();
        }

        // 画面表示
        private void LoginWindow_Load(object sender, EventArgs e)
        {
            // DB設定はConfigDB.xmlで行う
            s_configFileName = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            if (!File.Exists(s_configFileName))
            {
                // ログイン画面を閉じてチェックシート発行画面を表示する
                MessageBox.Show(MSG_DATABESE_CONFIG_NOT_EXSIST);
                this.Close();
            }
            s_DBManager = DBManager.GetInstance(s_configFileName);
#if false
            // Oracleバージョンドロップダウン設定
            OracleVerComboBox.Items.AddRange(new object[] { "Oracle 10g", "Oracle 11g" });

            // Schemaドロップダウン設定
            SchemaComboBox.Items.AddRange(new object[] { "KOKEN_1", "KOKEN_7" });
#endif

            // タイトルバー設定
            //this.Text = "[" + Assembly.GetExecutingAssembly().GetName().Name + "] "
            //    + MSG_TITLE_LOGIN_WINDOW
            //    +" - Ver." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.Text = "[KQA002SF] "
                + MSG_TITLE_LOGIN_WINDOW;

            // AppConfigの読込み
            LoadLoginSetting();

        }

        private void LoginWindow_Shown(Object sender, EventArgs e)
        {
            // フォーカスセット
            if (UserInfoResistCheckBox.Checked)
            {
                PasswordTextBox.Focus();
            }
        }
       
        // OKボタンクリック
        private void OkButton_Click(object sender, EventArgs e)
        {

            // 入力チェック
            if(UserIdTextBox.Text.Length == 0)
            {
                MessageBox.Show(MSG_USERID_NOT_ENTERED, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PasswordTextBox.Text.Length == 0)
            {
                MessageBox.Show(MSG_PASSWORD_NOT_ENTERED, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            // ユーザー情報・パスワードの存在チェック
            ProcessErrorType ret = s_DBManager.CheckUserInfoValid(UserIdTextBox.Text, PasswordTextBox.Text);
            if( ret == ProcessErrorType.None)
            {
                // ユーザーIDを記録するチェックボックスがONの場合は
                // AppConfigに保存する
                if (UserInfoResistCheckBox.Checked)
                {
                    SaveLoginSetting();
                }

                // ログイン画面を閉じてチェックシート発行画面を表示する
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else{
                // 入力に不備 or 認証情報取得失敗
                if(ret == ProcessErrorType.UserIdNotExist)
                {
                    // ユーザーIDが存在しない
                    MessageBox.Show(MSG_USERID_NOT_CORRECT, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(ret == ProcessErrorType.PasswordNotExist)
                {
                    // パスワードが存在しない(間違っている)
                    MessageBox.Show(MSG_PASSWORD_NOT_CORRECT, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(ret == ProcessErrorType.ConfigDbFileNotExist)
                {
                    // DB設定ファイルが存在しない
                    MessageBox.Show(MSG_DATABESE_CONFIG_NOT_EXSIST, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // DB接続失敗
                    MessageBox.Show(MSG_DATABESE_CONNECTION_FAILURE, MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // キャンセルボタンクリック
        private void CancelButton_Click(object sender, EventArgs e)
        {
  
            // アプリ終了
            SaveLoginSetting();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ログイン情報の読込み
        private void LoadLoginSetting()
        {
            // 前回起動時にユーザーIDを記録する にチェックが入っていた場合,
            // App.configからログイン情報を読込む
            if (ConfigurationManager.AppSettings["memUserID"] == "True")
            {
                OracleVerComboBox.Text = ConfigurationManager.AppSettings["oracleVer"];
                SchemaComboBox.Text = ConfigurationManager.AppSettings["schema"];
                UserIdTextBox.Text = ConfigurationManager.AppSettings["userID"];
                UserInfoResistCheckBox.Checked = true;
            }
        }

        // ログイン情報保存
        private void SaveLoginSetting()
        {

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["oracleVer"].Value = OracleVerComboBox.Text;
            config.AppSettings.Settings["schema"].Value = SchemaComboBox.Text;
            config.AppSettings.Settings["userID"].Value = UserIdTextBox.Text;
            config.AppSettings.Settings["memUserID"].Value = UserInfoResistCheckBox.Checked.ToString();
            config.Save();
        }

        // ×ボタン押下
        private void LoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLoginSetting();
        }

        private void UserIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { PasswordTextBox.Select(); }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { OkButton.Select(); }
        }
    }
}
