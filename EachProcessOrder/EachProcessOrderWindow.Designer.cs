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
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44753D, 1800D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44754D, 2500D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44757D, 3000D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44758D, 2800D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbKTGCD = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTehaiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispJissikiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispWideRangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varsionInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRefresh = new System.Windows.Forms.Button();
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
            this.cmbKTGCD.Size = new System.Drawing.Size(145, 29);
            this.cmbKTGCD.TabIndex = 0;
            this.cmbKTGCD.SelectedIndexChanged += new System.EventHandler(this.cmbKTGCD_SelectedIndexChanged);
            // 
            // chart
            // 
            stripLine1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            stripLine1.BorderWidth = 2;
            stripLine1.IntervalOffset = 2800D;
            chartArea1.AxisY.StripLines.Add(stripLine1);
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
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "工程能力値";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(568, 325);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.dispMenuItem,
            this.toolMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(586, 29);
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
            this.getTehaiMenuItem.Click += new System.EventHandler(this.getTehaiMenuItem_Click);
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
            this.dispJissikiMenuItem,
            this.dispNormalMenuItem,
            this.dispWideRangeMenuItem,
            this.toolStripMenuItem1,
            this.refreshMenuItem});
            this.dispMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dispMenuItem.Name = "dispMenuItem";
            this.dispMenuItem.Size = new System.Drawing.Size(81, 25);
            this.dispMenuItem.Text = "表示 (&V)";
            // 
            // dispJissikiMenuItem
            // 
            this.dispJissikiMenuItem.Name = "dispJissikiMenuItem";
            this.dispJissikiMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dispJissikiMenuItem.Text = "実績を取得しグラフに重ねる (&J)";
            this.dispJissikiMenuItem.Click += new System.EventHandler(this.dispJissikiMenuItem_Click);
            // 
            // dispNormalMenuItem
            // 
            this.dispNormalMenuItem.Name = "dispNormalMenuItem";
            this.dispNormalMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dispNormalMenuItem.Text = "表示期間を通常にする (&N)";
            this.dispNormalMenuItem.Click += new System.EventHandler(this.dispNormalMenuItem_Click);
            // 
            // dispWideRangeMenuItem
            // 
            this.dispWideRangeMenuItem.Name = "dispWideRangeMenuItem";
            this.dispWideRangeMenuItem.Size = new System.Drawing.Size(311, 26);
            this.dispWideRangeMenuItem.Text = "表示期間を長くする (&W)";
            this.dispWideRangeMenuItem.Click += new System.EventHandler(this.dispWideRangeMenuItem_Click);
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
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // toolMenuItem
            // 
            this.toolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolInputMenuItem,
            this.toolDeleteMenuItem});
            this.toolMenuItem.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolMenuItem.Name = "toolMenuItem";
            this.toolMenuItem.Size = new System.Drawing.Size(97, 25);
            this.toolMenuItem.Text = "ツール (&T)";
            // 
            // toolInputMenuItem
            // 
            this.toolInputMenuItem.Name = "toolInputMenuItem";
            this.toolInputMenuItem.Size = new System.Drawing.Size(426, 26);
            this.toolInputMenuItem.Text = "このパソコンに工程能力値を入力し保存する (&S)";
            this.toolInputMenuItem.Click += new System.EventHandler(this.toolInputMenuItem_Click);
            // 
            // toolDeleteMenuItem
            // 
            this.toolDeleteMenuItem.Name = "toolDeleteMenuItem";
            this.toolDeleteMenuItem.Size = new System.Drawing.Size(426, 26);
            this.toolDeleteMenuItem.Text = "このパソコンから工程能力値を削除する (&D)";
            this.toolDeleteMenuItem.Click += new System.EventHandler(this.toolDeleteMenuItem_Click);
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
            this.varsionInfoMenuItem.Click += new System.EventHandler(this.varsionInfoMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(586, 29);
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
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRefresh.Location = new System.Drawing.Point(458, 37);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(120, 29);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "グラフの更新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // cmbKTCD
            // 
            this.cmbKTCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKTCD.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKTCD.FormattingEnabled = true;
            this.cmbKTCD.Location = new System.Drawing.Point(158, 38);
            this.cmbKTCD.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKTCD.Name = "cmbKTCD";
            this.cmbKTCD.Size = new System.Drawing.Size(297, 29);
            this.cmbKTCD.TabIndex = 5;
            this.cmbKTCD.SelectedIndexChanged += new System.EventHandler(this.cmbKTCD_SelectedIndexChanged);
            // 
            // EachProcessOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 427);
            this.Controls.Add(this.cmbKTCD);
            this.Controls.Add(this.buttonRefresh);
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
        private System.Windows.Forms.ToolStripMenuItem dispJissikiMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispNormalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varsionInfoMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getTehaiMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox cmbKTCD;
        private System.Windows.Forms.ToolStripMenuItem dispWideRangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolInputMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteMenuItem;
    }
}

