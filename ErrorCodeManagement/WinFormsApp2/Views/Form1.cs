using WinFormsApp2.Controllers;
using WinFormsApp2.Models;

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

        /// <summary>
        /// フォームがロードされたときのイベントです。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            formController.LoadSettingFile();
        }

        /// <summary>
        /// フォームがクローズされたときのイベントです。
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            formController.SaveSettingFile();
        }

        /// <summary>
        /// ボタンがクリックされたときのイベントです。
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            formController.UpdateR2sPort(76543);
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
    }
}