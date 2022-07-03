using System;
using System.IO;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
// Debug用
using System.Threading;

namespace EachProcessOrder
{
    using static Common;

    public partial class EachProcessOrderWindow : Form
    {
        private string s_configFileName;
        private static DBManager s_DBManager;
        private static DataSet myDs;
        private static bool isDBUse;
        private static DateTime myToday;

        public EachProcessOrderWindow()
        {
            InitializeComponent();
        }

        // Window のロード処理
        private void EachProcessOrderWindow_Load(object sender, EventArgs e)
        {
            // フォーム初期化
            toolStatusLabel.Text = "";
            this.Text = "[Kxx00xxx] " + MSG_TITLE_WINDOW;

            // DB設定はConfigDB.xmlで行う
            s_configFileName = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            if (!File.Exists(s_configFileName))
            {
                MessageBox.Show(MSG_DATABESE_CONFIG_NOT_EXSIST);
                this.Close();
            }
            s_DBManager = DBManager.GetInstance(s_configFileName);
            if (DBManager.GetTargetDB() == "Oracle")
            {
                myToday = DateTime.Today;
            }
            else 
            {
                myToday = new DateTime(2022, 4, 5);
            }
        }

        // Window 初期表示時
        private void EachProcessOrderWindow_Shown(object sender, EventArgs e)
        {
            // データベースオープン
            if (DBManager.DBOpen() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CONNECTION_FAILURE);
                this.Close();
            }

            // データベースからデータ取得
            myDs = new DataSet();
            DBManager.SetM0400(ref myDs);
            DBManager.SetM0410(ref myDs);

            // データベースから非同期で手配データを取得
            isDBUse = true;
            toolStatusLabel.Text = "データベースから手配データの取得中...";
            Task t = Task.Run(() => { GetTehaiData(); });

            // 工程グループドロップダウン設定
            List<string> M0400 = myDs.Tables["M0400"].AsEnumerable()
            .OrderByDescending(row => row.Field<string>("KTGCD"))
            .Select(row => row.Field<string>("KTGCD") + ": " +
                            row.Field<string>("KTRNM") + " (" + row.Field<string>("KTGNM") + ")")
            .ToList();
            cmbKTGCD.Items.AddRange(M0400.ToArray());

            // イベント創出 ～ (工程データをDataTableからLinq取得しドロップダウンに設定させる)
            if (M0400.Count() > 0) cmbKTGCD.SelectedIndex = 0;

            // データベースクローズ
            if (isDBUse == false && DBManager.DBClose() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CLOSE_FAILURE);
                this.Close();
            }
            Console.WriteLine("WindowShown完:" + DateTime.Now.ToString("mm:ss:ffff"));
            // AppConfigの読込み
            LoadProcessSetting();
        }

        // データベースから手配データを非同期で取得
        private void GetTehaiData()
        {
            // データベースよりデータ取得 ⇒ DataSetへ格納
            var sw = Stopwatch.StartNew();
            var dt = DBManager.GetD0410();
            sw.Stop();
            Thread.Sleep(3000);

            // DataSetへ格納
            myDs.Tables.Add(dt);
            myDs.Tables[myDs.Tables.Count - 1].TableName = "D0410";
            isDBUse = false;
            if (DBManager.DBClose() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CLOSE_FAILURE);
                this.Close();
            }
            if (IsDataTable("D0410"))
            {
                var count = myDs.Tables["D0410"].Rows.Count.ToString("#,0");
                toolStatusLabel.Text = $"手配データ: {count}件を取得し準備が出来ました. ({sw.ElapsedMilliseconds}ミリ秒)";
            }
            else { toolStatusLabel.Text = ""; }
            Console.WriteLine("D0410取得完:" + DateTime.Now.ToString("mm:ss:ffff"));
        }

        private bool IsDataTable(string tablename)
        {
            for(int i = 0; i < myDs.Tables.Count; i++)
            {
                if (myDs.Tables[i].TableName == tablename) return true;
            }
            return false;
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
            DBManager.DBClose();
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
            this.Close();
        }

        // App.configから前回の工程情報を読込む
        private void LoadProcessSetting()
        {
            if (ConfigurationManager.AppSettings["ktgIdx"] == null) return;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktgIdx"], out int i)){ cmbKTGCD.SelectedIndex = i; }
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktIdx"], out int j)) { cmbKTCD.SelectedIndex = j; }
        }

        // 今回の工程情報を保存する
        private void SaveProcessSetting()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ktgIdx"].Value = cmbKTGCD.SelectedIndex.ToString();
            config.AppSettings.Settings["ktIdx"].Value = cmbKTCD.SelectedIndex.ToString();
            config.Save();
        }

        private void cmbKTCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDBUse) return;

            // DataTableから抽出～グループ化
            // チャート更新
            chart.Titles.Clear();
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            var fromdt = myToday.AddDays(-10).ToString("yyyy/MM/dd");
            var todt = myToday.AddDays(+10).ToString("yyyy/MM/dd");
            var str = cmbKTCD.SelectedItem.ToString();
            var ktcd = str.Substring(0, str.IndexOf(":"));

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("EDDTSTR", typeof(DateTime));
                dt.Columns.Add("SUMQTY", typeof(int));
                dt = myDs.Tables["D0410"]
                    .Select($"KTCD='{ktcd}' and EDDT>='{fromdt}' and EDDT<='{todt}'")
                    .AsEnumerable()
                    .GroupBy(grp => new
                    { EDDTKEY = grp.Field<DateTime>("EDDT") })
                    .Select(x =>
                    {
                        DataRow row = dt.NewRow();
                        row["EDDTSTR"] = x.Key.EDDTKEY;
                        row["SUMQTY"] = x.Sum(r => r.Field<int>("ODRQTY"));
                        return row;
                    }
                    )
                    .CopyToDataTable();

                // ChartArea
                Title title = new Title($"{str}: 日別集計");
                ChartArea area1 = new ChartArea();
                area1.AxisX.LabelStyle.Format = "MM/dd(ddd)";
                area1.AxisY.Title = "数量 (本数)";

                // Sreies
                Series series = new Series();
                series.LegendText = "手配データ";
                series.ChartType = SeriesChartType.Column;
                series.XValueType = ChartValueType.DateTime;
                foreach (DataRow result in dt.Rows)
                {
                    //取得した日付をシリアル値に変換 x.ToOADate() xは日付型
                    series.Points.Add(new DataPoint(DateTime.Parse(
                        result["EDDTSTR"].ToString()).ToOADate(), Convert.ToDouble(
                        result["SUMQTY"])));
                }

                chart.Titles.Add(title);
                chart.ChartAreas.Add(area1);
                chart.Series.Add(series);
            }
            catch (Exception ex)
            {
                Title title1 = new Title($"{str}: 手配データなし");
                chart.Titles.Add(title1);
            }
        }
    }
}
