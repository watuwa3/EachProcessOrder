
namespace EachProcessOrder
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OracleVerComboBox = new System.Windows.Forms.ComboBox();
            this.SchemaComboBox = new System.Windows.Forms.ComboBox();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserInfoResistCheckBox = new System.Windows.Forms.CheckBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.LoginCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::EachProcessOrder.Properties.Resources.PDCACycle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "接続先";
            // 
            // OracleVerComboBox
            // 
            this.OracleVerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OracleVerComboBox.FormattingEnabled = true;
            this.OracleVerComboBox.Items.AddRange(new object[] {
            "Oracle 11g"});
            this.OracleVerComboBox.Location = new System.Drawing.Point(466, 14);
            this.OracleVerComboBox.Name = "OracleVerComboBox";
            this.OracleVerComboBox.Size = new System.Drawing.Size(121, 20);
            this.OracleVerComboBox.TabIndex = 2;
            // 
            // SchemaComboBox
            // 
            this.SchemaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchemaComboBox.FormattingEnabled = true;
            this.SchemaComboBox.Items.AddRange(new object[] {
            "KOKEN_7",
            "KOKEN_5",
            "KOKEN_3",
            "KOKEN_1",
            "KOKEN_QA"});
            this.SchemaComboBox.Location = new System.Drawing.Point(466, 39);
            this.SchemaComboBox.Name = "SchemaComboBox";
            this.SchemaComboBox.Size = new System.Drawing.Size(121, 20);
            this.SchemaComboBox.TabIndex = 3;
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(385, 78);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(58, 12);
            this.UserIdLabel.TabIndex = 4;
            this.UserIdLabel.Text = "ユーザーID:";
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UserIdTextBox.Location = new System.Drawing.Point(466, 75);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(121, 19);
            this.UserIdTextBox.TabIndex = 5;
            this.UserIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserIdTextBox_KeyDown);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(385, 110);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(54, 12);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "パスワード:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PasswordTextBox.Location = new System.Drawing.Point(466, 107);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(121, 19);
            this.PasswordTextBox.TabIndex = 7;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyDown);
            // 
            // UserInfoResistCheckBox
            // 
            this.UserInfoResistCheckBox.AutoSize = true;
            this.UserInfoResistCheckBox.Location = new System.Drawing.Point(387, 158);
            this.UserInfoResistCheckBox.Name = "UserInfoResistCheckBox";
            this.UserInfoResistCheckBox.Size = new System.Drawing.Size(127, 16);
            this.UserInfoResistCheckBox.TabIndex = 8;
            this.UserInfoResistCheckBox.Text = "ユーザーIDを記録する";
            this.UserInfoResistCheckBox.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(387, 204);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(88, 38);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // LoginCancelButton
            // 
            this.LoginCancelButton.Location = new System.Drawing.Point(499, 204);
            this.LoginCancelButton.Name = "LoginCancelButton";
            this.LoginCancelButton.Size = new System.Drawing.Size(88, 38);
            this.LoginCancelButton.TabIndex = 10;
            this.LoginCancelButton.Text = "キャンセル";
            this.LoginCancelButton.UseVisualStyleBackColor = true;
            this.LoginCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 258);
            this.Controls.Add(this.LoginCancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.UserInfoResistCheckBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserIdTextBox);
            this.Controls.Add(this.UserIdLabel);
            this.Controls.Add(this.SchemaComboBox);
            this.Controls.Add(this.OracleVerComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログイン画面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginWindow_FormClosed);
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.Shown += new System.EventHandler(this.LoginWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OracleVerComboBox;
        private System.Windows.Forms.ComboBox SchemaComboBox;
        private System.Windows.Forms.Label UserIdLabel;
        private System.Windows.Forms.TextBox UserIdTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.CheckBox UserInfoResistCheckBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button LoginCancelButton;
    }
}