using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private DBManager s_DBManager;
        private DataSet myDs;

        public EachProcessOrderWindow()
        {
            InitializeComponent();
        }


        private void EachProcessOrderWindow_Load(object sender, EventArgs e)
        {
            // フォーム初期化
            myDs = new DataSet();
            myDs.Clear();
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
            if (s_DBManager.DBOpen() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CONNECTION_FAILURE);
                this.Close();
            };

            //工程グループテーブル設定
            // 工程グループドロップダウン設定
            s_DBManager.SetM0400(ref myDs);
            List<DataRow> list = new myDs.Tables["M0400"].AsEnumerable().ToList();
            cmbKTGCD.Items.AddRange(new object[] { "Oracle 10g", "Oracle 11g" });

            // 工程ドロップダウン設定
            cmbKTCD.Items.AddRange(new object[] { "KOKEN_1", "KOKEN_7" });


            // データベースよりコンボボックス設定
            // M0400 ktg wl mm mp kk be bt ct cw
            // M0410 kt 
        }

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

    }
}
