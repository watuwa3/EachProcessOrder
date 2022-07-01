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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbKTGCD = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTehaiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispMMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varsionInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTehai = new System.Windows.Forms.Button();
            this.cmbKTCD = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbKTGCD
            // 
            this.cmbKTGCD.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKTGCD.FormattingEnabled = true;
            this.cmbKTGCD.Location = new System.Drawing.Point(12, 47);
            this.cmbKTGCD.Name = "cmbKTGCD";
            this.cmbKTGCD.Size = new System.Drawing.Size(180, 31);
            this.cmbKTGCD.TabIndex = 0;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 84);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.MediumSlateBlue;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 10;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Yellow;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(776, 421);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.dispMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 39);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTehaiMenuItem,
            this.toolStripMenuItem2,
            this.closeMenuItem});
            this.fileMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(124, 35);
            this.fileMenuItem.Text = "ファイル (&F)";
            // 
            // getTehaiMenuItem
            // 
            this.getTehaiMenuItem.Name = "getTehaiMenuItem";
            this.getTehaiMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.getTehaiMenuItem.Size = new System.Drawing.Size(326, 36);
            this.getTehaiMenuItem.Text = "手配データ取得";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(323, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(326, 36);
            this.closeMenuItem.Text = "閉じる (&C)";
            // 
            // dispMenuItem
            // 
            this.dispMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispLMenuItem,
            this.dispMMenuItem,
            this.dispSMenuItem,
            this.toolStripMenuItem1,
            this.refreshMenuItem});
            this.dispMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dispMenuItem.Name = "dispMenuItem";
            this.dispMenuItem.Size = new System.Drawing.Size(108, 35);
            this.dispMenuItem.Text = "表示 (&V)";
            // 
            // dispLMenuItem
            // 
            this.dispLMenuItem.Name = "dispLMenuItem";
            this.dispLMenuItem.Size = new System.Drawing.Size(314, 36);
            this.dispLMenuItem.Text = "大 (&L)";
            // 
            // dispMMenuItem
            // 
            this.dispMMenuItem.Name = "dispMMenuItem";
            this.dispMMenuItem.Size = new System.Drawing.Size(314, 36);
            this.dispMMenuItem.Text = "中 (&M)";
            // 
            // dispSMenuItem
            // 
            this.dispSMenuItem.Name = "dispSMenuItem";
            this.dispSMenuItem.Size = new System.Drawing.Size(314, 36);
            this.dispSMenuItem.Text = "小 (&S)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(311, 6);
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshMenuItem.Size = new System.Drawing.Size(314, 36);
            this.refreshMenuItem.Text = "最新の状態に更新";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varsionInfoMenuItem});
            this.helpMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(120, 35);
            this.helpMenuItem.Text = "ヘルプ (&H)";
            // 
            // varsionInfoMenuItem
            // 
            this.varsionInfoMenuItem.Name = "varsionInfoMenuItem";
            this.varsionInfoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.varsionInfoMenuItem.Size = new System.Drawing.Size(281, 36);
            this.varsionInfoMenuItem.Text = "バージョン情報";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 37);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(220, 31);
            this.statusLabel.Text = "toolStripStatusLabel";
            // 
            // btnTehai
            // 
            this.btnTehai.AutoSize = true;
            this.btnTehai.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTehai.Location = new System.Drawing.Point(491, 47);
            this.btnTehai.Name = "btnTehai";
            this.btnTehai.Size = new System.Drawing.Size(297, 33);
            this.btnTehai.TabIndex = 4;
            this.btnTehai.Text = "手配データ取得 (F5)";
            this.btnTehai.UseVisualStyleBackColor = true;
            // 
            // cmbKTCD
            // 
            this.cmbKTCD.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKTCD.FormattingEnabled = true;
            this.cmbKTCD.Location = new System.Drawing.Point(198, 47);
            this.cmbKTCD.Name = "cmbKTCD";
            this.cmbKTCD.Size = new System.Drawing.Size(287, 31);
            this.cmbKTCD.TabIndex = 5;
            // 
            // EachProcessOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.cmbKTCD);
            this.Controls.Add(this.btnTehai);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.cmbKTGCD);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EachProcessOrderWindow";
            this.Text = "工程別 手配状況確認アプリ";
            this.Load += new System.EventHandler(this.EachProcessOrderWindow_Load);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispMMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varsionInfoMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getTehaiMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Button btnTehai;
        private System.Windows.Forms.ComboBox cmbKTCD;
    }
}

