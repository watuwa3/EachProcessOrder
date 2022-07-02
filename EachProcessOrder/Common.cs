namespace EachProcessOrder
{
    // エラー種別
    public enum ProcessErrorType
    {
        None,
        ConfigDbFileNotExist,           // DB設定ファイルが存在しない
        ConfigDbFileReadError,          // DB設定ファイル読込みエラー
        ConfigFsFileNotExist,           // FS設定ファイルが存在しない
        ConfigFsFileReadError,          // FS設定ファイル読込みエラー
        DatabaseConnectionFailed,       // DB接続失敗
        DatabaseNoData,                 // DBにデータが存在しない
        UserIdNotExist,                 // ユーザーIDが存在しない
        PasswordNotExist,               // パスワードが存在しない
        PasswordFaild,                  // パスワードが間違っている
    }

    class Common
    {
        public static readonly string configFileName = "ConfigDB.xml";
        // メッセージ定義
        // タイトル
        public static readonly string MSG_TITLE_LOGIN_WINDOW = "工程別 手配状況調査アプリ 認証画面";
        public static readonly string MSG_TITLE_WINDOW = "工程別 手配状況調査アプリ画面";
        public static readonly string MSG_TITLE_SUCCESS = "調査完了";
        public static readonly string MSG_TITLE_PROCESS = "処理中";
        public static readonly string MSG_TITLE_ERROR = "エラー";
        public static readonly string MSG_TITLE_ASK = "確認";

        // メッセージ
        public static readonly string MSG_PROCESSING = "手配調査中...";
        public static readonly string MSG_APP_END_ASK = "アプリを終了しますか?";

        // ファイル パス
        public static readonly string PATH_DELIMITER = "\\";                                     // パスのデリミタ
        public static readonly string ICON_FILE = @".\Koken.ico";                                // フォーム アイコン定義

        // エラーメッセージ
        public static readonly string MSG_USERID_NOT_ENTERED = "ユーザーIDが入力されていません";
        public static readonly string MSG_USERID_NOT_CORRECT = "ユーザーIDが間違っています";
        public static readonly string MSG_PASSWORD_NOT_ENTERED = "パスワードが入力されていません";
        public static readonly string MSG_PASSWORD_NOT_CORRECT = "パスワードが間違っています";
        public static readonly string MSG_PASSWORD_FAILD = "パスワードが間違っています";

        public static readonly string MSG_DATABESE_CONFIG_NOT_EXSIST = "データベース設定ファイルが存在しません\n設定ファイルを配置しアプリを再起動してください";
        public static readonly string MSG_FILE_CONFIG_NOT_EXSIST = "ファイル設定ファイルが存在しません\n設定ファイルを配置しアプリを再起動してください";
        public static readonly string MSG_DATABESE_CONNECTION_FAILURE = "データベースへの接続に失敗しました";
        public static readonly string MSG_DATABESE_CLOSE_FAILURE = "データベースへの切断に失敗しました";

    }

}
