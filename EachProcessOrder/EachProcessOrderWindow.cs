using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace EachProcessOrder
{
    using static Common;

    public partial class EachProcessOrderWindow : Form
    {
        private static string s_configFileName;
        private static string s_KTCD;
        private static DBManager s_DBManager;
        private static DataSet myDs;
        private static bool isDBUse;
        private static bool isNormalRange;  // 表示範囲
        private static DateTime myToday;    // Debug用
        private static Dictionary<string, int> s_DictionaryBase;

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
            this.Width = 700;
            s_DictionaryBase = new Dictionary<string, int>();

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

            // Debug用に基準値変更（データが少ないもので）
            if (DBManager.GetTargetDB() == "Oracle")
            {
                myToday = DateTime.Today;
            }
            else
            {
                myToday = new DateTime(2022, 4, 5);
            }
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
            toolStatusLabel.Text = MSG_PROCESSING;
            Task t = Task.Run(() => { GetTehaiData(); });

            // AppConfigの読込み
            LoadProcessSetting();
                 
            Console.WriteLine(MSG_DEBUG_LOAD_COMPLETED + ": " + DateTime.Now.ToString("mm:ss:ffff"));
        }

        public delegate void ChartUpdateDelegate();

        // データベースから非同期で手配データを取得 ⇒ DataSetへ格納
        private void GetTehaiData()
        {
            // データベースオープン（再取得用）
            if (DBManager.DBOpen() != ProcessErrorType.None)
            {
                MessageBox.Show(MSG_DATABESE_CONNECTION_FAILURE);
                this.Close();
            }
            isDBUse = true;

            // 手配データ再取得の場合
            if (IsDataTable("D0410"))
            {
                var dt2 = new DataTable();
                dt2 = myDs.Tables["D0410"];
                if (myDs.Tables.CanRemove(dt2)) { myDs.Tables.Remove(dt2); }
            }

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

            // チャートを表示 (Invoke:別スレッドからのアクセスが可能となるらしい）
            Invoke(new ChartUpdateDelegate(MakeChart));

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
        private void KTGCDChanged(string _ktgcd)
        {
            List<string> M0410 = myDs.Tables["M0410"].AsEnumerable()
                .Where(row => row.Field<string>("KTGCD") == _ktgcd.Substring(0, _ktgcd.IndexOf(":")))
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
            var ktgIndex = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktgIndex"], out ktgIndex))
            {
                if (cmbKTGCD.Items.Count <= ktgIndex) { ktgIndex = 0; }
            }
            if (cmbKTGCD.Items.Count > 0) { cmbKTGCD.SelectedIndex = ktgIndex; } // イベント創出(工程データをDataTableから取得しドロップダウンに設定させる為)

            var ktIndex = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["ktIndex"], out ktIndex))
            {
                if (cmbKTCD.Items.Count <= ktIndex) { cmbKTCD.SelectedIndex = 0; }
            }
            if (cmbKTCD.Items.Count > 0) { cmbKTCD.SelectedIndex = ktIndex; }
            var process1 = ConfigurationManager.AppSettings["processBase1"].Split(':');
            s_DictionaryBase.Add(process1[0], Int32.Parse(process1[1]));
            var process2 = ConfigurationManager.AppSettings["processBase2"].Split(':');
            s_DictionaryBase.Add(process2[0], Int32.Parse(process2[1]));
            var process3 = ConfigurationManager.AppSettings["processBase3"].Split(':');
            s_DictionaryBase.Add(process3[0], Int32.Parse(process3[1]));
        }

        // 今回の工程情報を保存する
        private void SaveProcessSetting()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ktgIndex"].Value = cmbKTGCD.SelectedIndex.ToString();
            config.AppSettings.Settings["ktIndex"].Value = cmbKTCD.SelectedIndex.ToString();
            var keys = s_DictionaryBase.Keys.ToList();
            var values = s_DictionaryBase.Values.ToList();
            for (var i = 0; i < s_DictionaryBase.Count; i++)
            {
                var j = i + 1;
                config.AppSettings.Settings["processBase" + j.ToString()].Value = keys[i] + ":" + values[i];
            }
            config.Save();
        }

        // 工程変更された場合
        private void cmbKTCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecteditem = cmbKTCD.SelectedItem.ToString();
            s_KTCD = selecteditem.Substring(0, selecteditem.IndexOf(":"));
            MakeChart();
        }

        // 手配データテーブルからチャート作成
        // 通常：前後7日
        // ワイド表示：前後30日
        public void MakeChart()
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

            // 工程能力値が設定されていれば取得
            int numberOfBase = 0;
            s_DictionaryBase.TryGetValue(s_KTCD, out numberOfBase);

            // DataTableから抽出～グループ化
            try
            {
                // 件数チェック
                if (myDs.Tables["D0410"]
                    .Select($"KTCD='{s_KTCD}' and EDDT>='{fromdt}' and EDDT<='{todt}'")
                    .Count() == 0)
                {
                    chart.Titles.Add($"{selecteditem}: {MSG_TITLE_D0410}なし");
                    return;
                }

                DataTable dtChart = new DataTable();
                dtChart.Columns.Add("EDDT", typeof(DateTime));
                dtChart.Columns.Add("SUMQTY", typeof(int));
                dtChart = myDs.Tables["D0410"]
                    .Select($"KTCD='{s_KTCD}' and EDDT>='{fromdt}' and EDDT<='{todt}'")
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
                Series series1 = new Series()
                {
                    LegendText = MSG_TITLE_D0410,
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.DateTime,
                    IsValueShownAsLabel = true,
                    LabelFormat = "#,0",
                };
                Series series2 = new Series();
                series2.LegendText = MSG_TITLE_NUMBER_BASE;
                foreach (DataRow result in dtChart.Rows)
                {
                    //取得した日付をシリアル値に変換 x.ToOADate() xは日付型
                    Double _eddt = DateTime.Parse(result["EDDT"].ToString()).ToOADate();
                    series1.Points.Add(new DataPoint(_eddt, Convert.ToDouble(result["SUMQTY"])));
                }
                chart.Titles.Add($"{selecteditem}: {MSG_TITLE_DAYLY_SUMMARY}");
                chart.ChartAreas.Add(area1);
                chart.Series.Add(series1);

                // 工程能力値の水平線を表示する。
                if (numberOfBase != 0)
                {
                    double _base = Convert.ToDouble(numberOfBase);
                    StripLine stlipLine = new StripLine
                    {
                        //Text = $"工程能力値:{mean}",
                        //TextAlignment = StringAlignment.Near,       // テキストの水平位置（Near:左, Center:中央, Far:右）
                        //TextLineAlignment = StringAlignment.Far,    // テキストの垂直位置（Near:下, Center:中央, Far:上）
                        Interval = 0,                               // 線分の表示間隔 値を設定すると指定した間隔で表示される。
                        IntervalOffset = _base,                     // 線分の表示オフセット
                        BorderWidth = 3,
                        BorderDashStyle = ChartDashStyle.Solid,
                        BorderColor = Color.Orange,
                    };
                    chart.ChartAreas[0].AxisY.StripLines.Add(stlipLine);
                    chart.Series.Add(series2);
                }
            }
            catch (Exception ex)
            {
                chart.Titles.Add($"{selecteditem}: {MSG_PROGRAM_ERROR}");
            }
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
            isDBUse = true;
            toolStatusLabel.Text = MSG_PROCESSING;
            Task t = Task.Run(() => { GetTehaiData(); });
        }

        // 製品バージョン情報の表示
        private void varsionInfoMenuItem_Click(object sender, EventArgs e)
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var v = fileVersionInfo.ProductVersion;
            MessageBox.Show(MSG_PRODUCT_VERSION + v.ToString(), MSG_TITLE_WINDOW);
        }

        // 再表示ボタン
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MakeChart();
        }

        // 実績データ取得
        private void dispJissikiMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未実装");
        }

        // 工程能力値の入力
        private void toolInputMenuItem_Click(object sender, EventArgs e)
        {
            if (!s_DictionaryBase.ContainsKey(s_KTCD) && s_DictionaryBase.Count >= 3)
            {
                MessageBox.Show(MSG_OVER_BASE, MSG_TITLE_WINDOW);
                return;
            }
            var str = Interaction.InputBox(MSG_INPUT_PROCESS_BASE, MSG_TITLE_WINDOW);
            if (!Int32.TryParse(str, out int num))
            {
                MessageBox.Show(MSG_NOT_NUMERIC, MSG_TITLE_WINDOW);
                return;
            }
            s_DictionaryBase[s_KTCD] = num;
            MakeChart();
        }

        // 工程能力値の削除
        private void toolDeleteMenuItem_Click(object sender, EventArgs e)
        {
            s_DictionaryBase.Remove(s_KTCD);
            MakeChart();
        }
    }
}
