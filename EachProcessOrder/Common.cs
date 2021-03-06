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
        public static readonly string MSG_TITLE_LOGIN_WINDOW = "手配状況調査 認証画面";
        public static readonly string MSG_TITLE_WINDOW = "[KMD001SF] 手配状況調査";
        public static readonly string MSG_TITLE_SUCCESS = "調査完了";
        public static readonly string MSG_TITLE_PROCESS = "処理中";
        public static readonly string MSG_TITLE_ERROR = "エラー";
        public static readonly string MSG_TITLE_ASK = "確認";
        public static readonly string MSG_TITLE_D0410 = "手配データ";
        public static readonly string MSG_TITLE_DAYLY_SUMMARY = "日別集計";
        public static readonly string MSG_TITLE_AREA_AXISY = "数量 (本数)";
        public static readonly string MSG_TITLE_NUMBER_BASE = "工程能力値";
        
        // メッセージ
        public static readonly string MSG_PRODUCT_VERSION = "製品バージョン: ";
        public static readonly string MSG_PROCESSING = "データベースから手配データの取得中...";
        public static readonly string MSG_APP_END_ASK = "アプリを終了しますか?";
        public static readonly string MSG_DATA_NOT_FOUND = "データ取得出来ませんでした";
        public static readonly string MSG_DEBUG_LOAD_COMPLETED = "初期フォーム表示完了";
        public static readonly string MSG_DEBUG_D0410_READYTOGO = "手配データを取得し準備が出来ました";
        public static readonly string MSG_INPUT_PROCESS_BASE = "工程能力値を入力してください";

        // ファイル パス
        public static readonly string PATH_DELIMITER = "\\";                                     // パスのデリミタ
        public static readonly string ICON_FILE = @".\Koken.ico";                                // フォーム アイコン定義

        // エラーメッセージ
        public static readonly string MSG_USERID_NOT_ENTERED = "ユーザーIDが入力されていません";
        public static readonly string MSG_USERID_NOT_CORRECT = "ユーザーIDが間違っています";
        public static readonly string MSG_PASSWORD_NOT_ENTERED = "パスワードが入力されていません";
        public static readonly string MSG_PASSWORD_NOT_CORRECT = "パスワードが間違っています";
        public static readonly string MSG_PASSWORD_FAILD = "パスワードが間違っています";
        public static readonly string MSG_NOT_NUMERIC = "数値を入力してください";
        public static readonly string MSG_OVER_BASE = "３工程以上はこのパソコン上に登録出来ません";

        public static readonly string MSG_DATABESE_CONFIG_NOT_EXSIST = "データベース設定ファイルが存在しません\n設定ファイルを配置しアプリを再起動してください";
        public static readonly string MSG_FILE_CONFIG_NOT_EXSIST = "ファイル設定ファイルが存在しません\n設定ファイルを配置しアプリを再起動してください";
        public static readonly string MSG_DATABESE_CONNECTION_FAILURE = "データベースへの接続に失敗しました";
        public static readonly string MSG_DATABESE_CLOSE_FAILURE = "データベースへの切断に失敗しました";

        public static readonly string MSG_PROGRAM_ERROR = "プログラムの想定エラーが発生しました";

    }

}
