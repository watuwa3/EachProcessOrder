using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace EachProcessOrder
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ログイン画面表示
            LoginWindow loginWindow = new LoginWindow();
            DialogResult dialogResult = loginWindow.ShowDialog();

            // ログイン処理が正常に完了したか?
            if (dialogResult == DialogResult.OK)
            {
                // チェックシート発行画面表示
                // ChecksheetIssueWindow issueWindow = new ChecksheetIssueWindow();
                // issueWindow.ShowDialog();
                Application.Run(new EachProcessOrderWindow());
            }
        }
    }
}
