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
        private static bool isNormalRange;  // 表示範囲
        private static DateTime myToday;    // Debug用

        public EachProcessOrderWindow()
        {
            InitializeComponent();
        }

        // Windowのロード処理
        private void EachProcessOrderWindow_Load(object sender, EventArgs e)
        {
            // フォーム初期化
            toolStatusLabel.Text = "";
            this.Text = MSG_TITLE_WINDOW;

            // フラグ初期化
            isNormalRange = true;

            // DB設定はConfigDB.xmlで行う
            s_configFileName = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            if (!File.Exists(s_configFileName))
            {
                MessageBox.Show(MSG_DATABESE_CONFIG_NOT_EXSIST);
                this.Close();
            }
            s_DBManager = DBManager.GetInstance(s_configFileName);

            // Debug用に設定値変更
            if (DBManager.GetTargetDB() == "Oracle"){myToday = DateTime.Today;}
            else {myToday = new DateTime(2022, 4, 5);}
        }

        // Window初期表示時処理
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

            // 工程グループドロップダウン設定
            List<string> M0400 = myDs.Tables["M0400"].AsEnumerable()
            .OrderByDescending(row => row.Field<string>("KTGCD"))
            .Select(row => row.Field<string>("KTGCD") + ": " +
                            row.Field<string>("KTGRNM") + " (" + row.Field<string>("KTGRNM") + ")")
            .ToList();
            cmbKTGCD.Items.AddRange(M0400.ToArray());

            // データベースから非同期で手配データを取得
            isDBUse = true;
            toolStatusLabel.Text = MSG_PROCESSING;
            Task t = Task.Run(() => { GetTehaiData(); });

            // AppConfigの読込み
            LoadProcessSetting();
            this.Width = 700;
                 
            Console.WriteLine(MSG_DEBUG_LOAD_COMPLETED + ": " + DateTime.Now.ToString("mm:ss:ffff"));
        }

        // データベースから非同期で手配データを取得 ⇒ DataSetへ格納
        private void GetTehaiData()
        {
            // 手配データ取得（前月1日から来月末まで3か月間の全データ）
            var sw = Stopwatch.StartNew(); // 処理時間を計測
            var dt = DBManager.GetD0410(myToday); 
            sw.Stop();

            Thread.Sleep(3000); // Debug用

            // DataSetへ格納
            myDs.Tables.Add(dt);
            myDs.Tables[myDs.Tables.Count - 1].TableName = "D0410";
            isDBUse = false;

            // データベースクローズ
            if (DBManager.DBClose() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CLOSE_FAILURE);
                this.Close();
            }

            // 結果をステータスバーに表示
            if (IsDataTable("D0410"))
            {
                var count = myDs.Tables["D0410"].Rows.Count.ToString("#,0");
                toolStatusLabel.Text = $"{MSG_DEBUG_D0410_READYTOGO} : {count}件 ({sw.ElapsedMilliseconds}ミリ秒)";
            }
            else { toolStatusLabel.Text = ""; }

            // チャートを表示
            MakeChart();

            Console.WriteLine(MSG_DEBUG_D0410_READYTOGO + ": " + DateTime.Now.ToString("mm:ss:ffff"));
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
                     buttonRefresh.Visible = false;
                else buttonRefresh.Visible = true;
                if (this.Width < 400) 
                    this.Width = 400;
                else chart.Width = this.Width - 34;
                if (this.Height < 300)
                    this.Height = 300;
                else chart.Height = this.Height - 129;
                // コントロールの表示場所をフォームの右端に設定
                buttonRefresh.Left = this.Width - buttonRefresh.Width - 30;
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
            var ktgidx = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktgIdx"], out ktgidx))
            {
                if (cmbKTGCD.Items.Count <= ktgidx)
                {
                    ktgidx = 0;
                }
            }
            if (cmbKTGCD.Items.Count > 0) { cmbKTGCD.SelectedIndex = ktgidx; } // イベント創出(工程データをDataTableから取得しドロップダウンに設定させる為)

            var ktidx = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktIdx"], out ktidx))
            {
                if (cmbKTCD.Items.Count <= ktidx)
                {
                    cmbKTCD.SelectedIndex = 0;
                }
            }
            if (cmbKTCD.Items.Count > 0) { cmbKTCD.SelectedIndex = ktidx; }
        }

        // 今回の工程情報を保存する
        private void SaveProcessSetting()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ktgIdx"].Value = cmbKTGCD.SelectedIndex.ToString();
            config.AppSettings.Settings["ktIdx"].Value = cmbKTCD.SelectedIndex.ToString();
            config.Save();
        }

        // 工程変更された場合
        private void cmbKTCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeChart();
        }

        // 手配データテーブルからチャート作成
        // 通常：前後7日
        // ワイド表示：前後30日
        private void MakeChart()
        {
            chart.Titles.Clear();
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            if (isDBUse) return; // 手配抽出(非同期)の処理中の場合は処理をキャンセルさせる

            string fromdt = "";
            string todt = "";
            if (isNormalRange)
            {
                fromdt = myToday.AddDays(-7).ToString("yyyy/MM/dd");
                todt = myToday.AddDays(+7).ToString("yyyy/MM/dd");
            }
            else
            {
                fromdt = myToday.AddDays(-30).ToString("yyyy/MM/dd");
                todt = myToday.AddDays(+30).ToString("yyyy/MM/dd");
            }
            var selecteditem = cmbKTCD.SelectedItem.ToString();
            var ktcd = selecteditem.Substring(0, selecteditem.IndexOf(":"));

            // DataTableから抽出～グループ化
            try
            {
                // 件数チェック
                if (myDs.Tables["D0410"]
                    .Select($"KTCD='{ktcd}' and EDDT>='{fromdt}' and EDDT<='{todt}'")
                    .Count() == 0)
                {
                    chart.Titles.Add($"{selecteditem}: {MSG_TITLE_D0410}なし");
                    return;
                }

                DataTable dtChart = new DataTable();
                dtChart.Columns.Add("EDDT", typeof(DateTime));
                dtChart.Columns.Add("SUMQTY", typeof(int));
                dtChart = myDs.Tables["D0410"]
                    .Select($"KTCD='{ktcd}' and EDDT>='{fromdt}' and EDDT<='{todt}'")
                    .AsEnumerable()
                    .GroupBy(grp => new { EDDTKEY = grp.Field<DateTime>("EDDT") })
                    .Select(x =>
                    {
                        DataRow row = dtChart.NewRow();
                        row["EDDT"] = x.Key.EDDTKEY;
                        row["SUMQTY"] = x.Sum(r => r.Field<int>("ODRQTY"));
                        return row;
                    }
                    )
                    .CopyToDataTable();

                // ChartArea
                ChartArea area1 = new ChartArea();
                area1.AxisX.LabelStyle.Format = "MM/dd(ddd)";
                area1.AxisY.Title = MSG_TITLE_AREA_AXISY;

                // Sreies
                Series series = new Series();
                series.LegendText = MSG_TITLE_D0410;
                series.ChartType = SeriesChartType.Column;
                series.XValueType = ChartValueType.DateTime;
                foreach (DataRow result in dtChart.Rows)
                {
                    //取得した日付をシリアル値に変換 x.ToOADate() xは日付型
                    series.Points.Add(new DataPoint(DateTime.Parse(
                        result["EDDT"].ToString()).ToOADate(), Convert.ToDouble(
                        result["SUMQTY"])));
                }

                chart.Titles.Add($"{selecteditem}: {MSG_TITLE_DAYLY_SUMMARY}");
                chart.ChartAreas.Add(area1);
                chart.Series.Add(series);
            }
            catch (Exception ex)
            {
                chart.Titles.Add($"{selecteditem}: {MSG_TITLE_D0410}なし");
            }

        }

        private void dispJissikiMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        private void dispBaseMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        // 表示する期間を長く設定し表示
        private void dispWideRangeMenuItem_Click(object sender, EventArgs e)
        {
            isNormalRange = false;
            MakeChart();
        }

        // 表示する期間を通常に戻し表示
        private void dispNormalMenuItem_Click(object sender, EventArgs e)
        {
            isNormalRange = true;
            MakeChart();
        }

        // 再表示メニュー
        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            MakeChart();
        }

        // 手配データ再取得
        private void getTehaiMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        // 工程能力値の入力
        private void toolInputMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        // バージョン情報
        private void varsionInfoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        // 再表示ボタン
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MakeChart();
        }
    }
}
