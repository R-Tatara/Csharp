namespace WinFormsApp2.Models
{
    /// <summary>
    /// エラーメッセージの属性を管理するためのクラスです。
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// メッセージボックスに表示するエラーコードです。
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// メッセージボックスのタイトルです。
        /// </summary>
        public string title { get; set; } = "MELFA Cloud Connector";

        /// <summary>
        /// メッセージボックスの内容です。
        /// </summary>
        public string message { get; set; } = "";

        /// <summary>
        /// メッセージボックスのボタン種別です。
        /// </summary>
        public MessageBoxButtons button { get; set; }

        /// <summary>
        /// メッセージボックスのアイコン種別です。
        /// </summary>
        public MessageBoxIcon icon { get; set; }
    }
}
