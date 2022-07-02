using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EachProcessOrder
{
    using static Common;

    public partial class EachProcessOrderWindow : Form
    {
        private string s_configFileName;
        private static DBManager s_DBManager;
        private static DataSet myDs;

        public EachProcessOrderWindow()
        {
            InitializeComponent();
        }

        // Windows のロード処理
        private void EachProcessOrderWindow_Load(object sender, EventArgs e)
        {
            // フォーム初期化
            statusLabel.Text = "";
            this.Text = "[Kxx00xxx] " + MSG_TITLE_WINDOW;

            // DB設定はConfigDB.xmlで行う
            s_configFileName = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            if (!File.Exists(s_configFileName))
            {
                MessageBox.Show(MSG_DATABESE_CONFIG_NOT_EXSIST);
                this.Close();
            }
            s_DBManager = DBManager.GetInstance(s_configFileName);

            // データベースオープン
            if (DBManager.DBOpen() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CONNECTION_FAILURE);
                this.Close();
            }

            // データベースよりデータ取得 ⇒ DataSetへ格納
            myDs = new DataSet();
            DBManager.SetM0400(ref myDs);
            DBManager.SetM0410(ref myDs);

            // データベースクローズ
            if (DBManager.DBClose() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CLOSE_FAILURE);
                this.Close();
            }
        }

        // Windows 初期表示時
        private void EachProcessOrderWindow_Shown(object sender, EventArgs e)
        {
            // 工程グループドロップダウン設定
            List<string> M0400 = myDs.Tables["M0400"].AsEnumerable()
                .OrderByDescending(row => row.Field<string>("KTGCD"))
                .Select(row => row.Field<string>("KTGCD") + ": " +
                               row.Field<string>("KTRNM") + " (" + row.Field<string>("KTGNM") + ")")
                .ToList();
            cmbKTGCD.Items.AddRange(M0400.ToArray());

            // イベント創出 ～ (工程データをDataTableからLinq取得しドロップダウンに設定させる)
            if (M0400.Count() > 0) cmbKTGCD.SelectedIndex = 0;

            // AppConfigの読込み
            LoadProcessSetting();
        }

        // FormResizeイベント
        private void EachProcessOrderWindow_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                if (this.Width < 620)
                     btnTehai.Visible = false;
                else btnTehai.Visible = true;
                if (this.Width < 400) 
                    this.Width = 400;
                else chart.Width = this.Width - 34;
                if (this.Height < 300)
                    this.Height = 300;
                else chart.Height = this.Height - 129;
                // コントロールのサイズをフォームの大きさから設定
                btnTehai.Left = this.Width - btnTehai.Width - 30;
            }
        }

        // ×ボタン押下
        private void EachProcessOrderWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveProcessSetting();
        }

        // 工程グループドロップダウン変更イベント
        private void cmbKTGCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKTCD.Items.Clear();
            KTGCDChanged(cmbKTGCD.SelectedItem.ToString());
        }

        // 工程ドロップダウンの再設定処理
        private void KTGCDChanged(string ktgcd)
        {
            List<string> M0410 = myDs.Tables["M0410"].AsEnumerable()
                .Where(row => row.Field<string>("KTGCD") == ktgcd.Substring(0, ktgcd.IndexOf(":")))
                .OrderBy(row => row.Field<string>("KTCD"))
                .Select(row => row.Field<string>("KTCD") + ": " +
                               row.Field<string>("KTNM") + " (" + row.Field<string>("ODCD") + ")")
                .ToList();
            cmbKTCD.Items.AddRange(M0410.ToArray());
            if (M0410.Count() > 0) cmbKTCD.SelectedIndex = 0;
        }

        // アプリ終了
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            SaveProcessSetting();
            this.Close();
        }

        // App.configから前回の工程情報を読込む
        private void LoadProcessSetting()
        {
            if (ConfigurationManager.AppSettings["ktgIdx"] == null) return;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktgIdx"], out int i))
                { cmbKTGCD.SelectedIndex = Int32.Parse(ConfigurationManager.AppSettings["ktgIdx"]); }
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktIdx"], out int j))
                cmbKTCD.SelectedIndex = Int32.Parse(ConfigurationManager.AppSettings["ktIdx"]);
        }

        // 今回の工程情報を保存する
        private void SaveProcessSetting()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ktgIdx"].Value = cmbKTGCD.SelectedIndex.ToString();
            config.AppSettings.Settings["ktIdx"].Value = cmbKTCD.SelectedIndex.ToString();
            config.Save();
        }

    }
}
