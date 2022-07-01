using System;
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
        public EachProcessOrderWindow()
        {
            InitializeComponent();
        }

        public DataSet myDs = new DataSet();

        private void EachProcessOrderWindow_Load(object sender, EventArgs e)
        {
            //初期化
            myDs.Clear();
            this.Text = "[Kxx00xxx] " + MSG_TITLE_WINDOW;

            statusLabel.Text = "";
            
            // データベースよりコンボボックス設定
            // M0400 ktg wl mm mp kk be bt ct cw
            // M0410 kt 

        }
    }
}
