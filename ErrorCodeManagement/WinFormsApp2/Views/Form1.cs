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
        /// �t�H�[�������[�h���ꂽ�Ƃ��̃C�x���g�ł��B
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            formController.LoadSettingFile();
        }

        /// <summary>
        /// �t�H�[�����N���[�Y���ꂽ�Ƃ��̃C�x���g�ł��B
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            formController.SaveSettingFile();
        }

        /// <summary>
        /// �{�^�����N���b�N���ꂽ�Ƃ��̃C�x���g�ł��B
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            formController.UpdateNetworkPort(76543);
        }

        /// <summary>
        /// �G���[���b�Z�[�W��\�����܂��B
        /// �G���[�ԍ������݂��Ȃ���΁A�G���[���b�Z�[�W�\�����܂��B
        /// </summary>
        /// <param name="errorCode">�\���������G���[�ԍ�</param>
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