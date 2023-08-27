using WinFormsApp2.Controllers;
using WinFormsApp2.Models;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private FormController formController;
        private ErrorTable errorTable;

        public Form1()
        {
            InitializeComponent();
            formController = new FormController(this);
            errorTable = new ErrorTable();
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
            formController.UpdateNetworkPort(76543);
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// エラー番号が存在しなければ、エラーメッセージ表示します。
        /// </summary>
        /// <param name="errorCode">表示したいエラー番号</param>
        public void ShowErrorMessageBox(int errorCode)
        {
            ErrorModel errorInfo = errorTable.GetErrorInfo(errorCode);
            if (errorInfo != null)
            {
                MessageBox.Show(errorInfo.message, errorInfo.title, errorInfo.button, errorInfo.icon);
            }
            else
            {
                MessageBox.Show("Error code not found.",
                    "MELFA Cloud Connector",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}