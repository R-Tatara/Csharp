using WinFormsApp2.Controllers;
using WinFormsApp2.Models;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private FormController formController;

        public Form1()
        {
            InitializeComponent();
            formController = new FormController(this);
        }

        //[TODO]引数の説明を追加
        /// <summary>
        /// フォームがロードされたときのイベントです。
        /// 設定ファイルを読み込みます。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            formController.LoadSettingFile();
        }

        //[TODO]引数の説明を追加
        /// <summary>
        /// フォームがクローズされたときのイベントです。
        /// 設定ファイルを書き出します。
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            formController.SaveSettingFile();
        }

        //[TODO]引数の説明を追加
        /// <summary>
        /// ボタンがクリックされたときのイベントです。
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            formController.UpdateR2sInfo("192.168.0.101", 7654);
        }

        /// <summary>
        /// メッセージを表示します。
        /// </summary>
        /// <param name="infoMessage">表示したい情報の文字列</param>
        public void ShowInfoMessageBox(string infoMessage)
        {
            if (infoMessage != null)
            {
                MessageBox.Show(infoMessage, "MELFA Cloud Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="errorModel">表示したいエラーの情報</param>
        public void ShowErrorMessageBox(ErrorModel errorModel)
        {
            if (errorModel != null)
            {
                MessageBox.Show(errorModel.message, errorModel.title, errorModel.button, errorModel.icon);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formController.AddNewRc("192.168.0.102", 6789);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formController.UpdateRcInfo(1, "127.0.0.1", 123);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formController.DeleteRc(0);
        }
    }
}