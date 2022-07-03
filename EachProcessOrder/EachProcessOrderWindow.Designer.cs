namespace EachProcessOrder
{
    partial class EachProcessOrderWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44753D, 1800D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44754D, 2500D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44757D, 3000D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44758D, 2800D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44753D, 1200D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44754D, 800D);
            this.cmbKTGCD = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTehaiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工程能力値を表示KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示期間を長くするWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispMMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varsionInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTehai = new System.Windows.Forms.Button();
            this.cmbKTCD = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbKTGCD
            // 
            this.cmbKTGCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKTGCD.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKTGCD.FormattingEnabled = true;
            this.cmbKTGCD.Location = new System.Drawing.Point(9, 38);
            this.cmbKTGCD.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKTGCD.Name = "cmbKTGCD";
            this.cmbKTGCD.Size = new System.Drawing.Size(154, 29);
            this.cmbKTGCD.TabIndex = 0;
            this.cmbKTGCD.SelectedIndexChanged += new System.EventHandler(this.cmbKTGCD_SelectedIndexChanged);
            // 
            // chart
            // 
            chartArea1.AxisY.Title = "本数";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(9, 71);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.MediumSlateBlue;
            series1.IsValueShownAsLabel = true;
            series1.LabelAngle = 45;
            series1.LabelFormat = "#,0";
            series1.Legend = "Legend1";
            series1.Name = "手配データ";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderWidth = 10;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Yellow;
            series2.Legend = "Legend1";
            series2.Name = "実績データ";
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(582, 325);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.dispMenuItem,
            this.設定SToolStripMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTehaiMenuItem,
            this.toolStripMenuItem2,
            this.closeMenuItem});
            this.fileMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(112, 25);
            this.fileMenuItem.Text = "ファイル (&F)";
            // 
            // getTehaiMenuItem
            // 
            this.getTehaiMenuItem.Name = "getTehaiMenuItem";
            this.getTehaiMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.getTehaiMenuItem.Size = new System.Drawing.Size(268, 26);
            this.getTehaiMenuItem.Text = "手配データ再取得";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(265, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(268, 26);
            this.closeMenuItem.Text = "閉じる (&C)";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // dispMenuItem
            // 
            this.dispMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispLMenuItem,
            this.工程能力値を表示KToolStripMenuItem,
            this.表示期間を長くするWToolStripMenuItem,
            this.dispSMenuItem,
            this.toolStripMenuItem1,
            this.refreshMenuItem});
            this.dispMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dispMenuItem.Name = "dispMenuItem";
            this.dispMenuItem.Size = new System.Drawing.Size(81, 25);
            this.dispMenuItem.Text = "表示 (&V)";
            // 
            // dispLMenuItem
            // 
            this.dispLMenuItem.Name = "dispLMenuItem";
            this.dispLMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dispLMenuItem.Text = "実績を取得しグラフに重ねる (&J)";
            // 
            // 工程能力値を表示KToolStripMenuItem
            // 
            this.工程能力値を表示KToolStripMenuItem.Name = "工程能力値を表示KToolStripMenuItem";
            this.工程能力値を表示KToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.工程能力値を表示KToolStripMenuItem.Text = "工程能力値を表示 (&K)";
            // 
            // 表示期間を長くするWToolStripMenuItem
            // 
            this.表示期間を長くするWToolStripMenuItem.Name = "表示期間を長くするWToolStripMenuItem";
            this.表示期間を長くするWToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.表示期間を長くするWToolStripMenuItem.Text = "表示期間を長くする (&W)";
            // 
            // dispSMenuItem
            // 
            this.dispSMenuItem.Name = "dispSMenuItem";
            this.dispSMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dispSMenuItem.Text = "表示期間を通常にする (&N)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(308, 6);
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshMenuItem.Size = new System.Drawing.Size(311, 26);
            this.refreshMenuItem.Text = "グラフを最新の状態に更新";
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispMMenuItem});
            this.設定SToolStripMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(97, 25);
            this.設定SToolStripMenuItem.Text = "ツール (&T)";
            // 
            // dispMMenuItem
            // 
            this.dispMMenuItem.Name = "dispMMenuItem";
            this.dispMMenuItem.Size = new System.Drawing.Size(426, 26);
            this.dispMMenuItem.Text = "このパソコンに工程能力値を入力し保存する (&S)";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varsionInfoMenuItem});
            this.helpMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(99, 25);
            this.helpMenuItem.Text = "ヘルプ (&H)";
            // 
            // varsionInfoMenuItem
            // 
            this.varsionInfoMenuItem.Name = "varsionInfoMenuItem";
            this.varsionInfoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.varsionInfoMenuItem.Size = new System.Drawing.Size(230, 26);
            this.varsionInfoMenuItem.Text = "バージョン情報";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(600, 29);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStatusLabel
            // 
            this.toolStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStatusLabel.Name = "toolStatusLabel";
            this.toolStatusLabel.Size = new System.Drawing.Size(136, 24);
            this.toolStatusLabel.Text = "toolStatusLabel";
            // 
            // btnTehai
            // 
            this.btnTehai.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTehai.Location = new System.Drawing.Point(423, 38);
            this.btnTehai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTehai.Name = "btnTehai";
            this.btnTehai.Size = new System.Drawing.Size(168, 29);
            this.btnTehai.TabIndex = 4;
            this.btnTehai.Text = "手配データ再取得";
            this.btnTehai.UseVisualStyleBackColor = true;
            // 
            // cmbKTCD
            // 
            this.cmbKTCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKTCD.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKTCD.FormattingEnabled = true;
            this.cmbKTCD.Location = new System.Drawing.Point(167, 38);
            this.cmbKTCD.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKTCD.Name = "cmbKTCD";
            this.cmbKTCD.Size = new System.Drawing.Size(252, 29);
            this.cmbKTCD.TabIndex = 5;
            this.cmbKTCD.SelectedIndexChanged += new System.EventHandler(this.cmbKTCD_SelectedIndexChanged);
            // 
            // EachProcessOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 427);
            this.Controls.Add(this.cmbKTCD);
            this.Controls.Add(this.btnTehai);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.cmbKTGCD);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EachProcessOrderWindow";
            this.Text = "工程別 手配状況確認アプリ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EachProcessOrderWindow_FormClosed);
            this.Load += new System.EventHandler(this.EachProcessOrderWindow_Load);
            this.Shown += new System.EventHandler(this.EachProcessOrderWindow_Shown);
            this.SizeChanged += new System.EventHandler(this.EachProcessOrderWindow_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKTGCD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varsionInfoMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getTehaiMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Button btnTehai;
        private System.Windows.Forms.ComboBox cmbKTCD;
        private System.Windows.Forms.ToolStripMenuItem 工程能力値を表示KToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示期間を長くするWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispMMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

