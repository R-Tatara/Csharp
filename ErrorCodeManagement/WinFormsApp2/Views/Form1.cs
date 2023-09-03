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

        //[TODO]�����̐�����ǉ�
        /// <summary>
        /// �t�H�[�������[�h���ꂽ�Ƃ��̃C�x���g�ł��B
        /// �ݒ�t�@�C����ǂݍ��݂܂��B
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            formController.LoadSettingFile();
        }

        //[TODO]�����̐�����ǉ�
        /// <summary>
        /// �t�H�[�����N���[�Y���ꂽ�Ƃ��̃C�x���g�ł��B
        /// �ݒ�t�@�C���������o���܂��B
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            formController.SaveSettingFile();
        }

        //[TODO]�����̐�����ǉ�
        /// <summary>
        /// �{�^�����N���b�N���ꂽ�Ƃ��̃C�x���g�ł��B
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            formController.UpdateR2sInfo("192.168.0.101", 7654);
        }

        /// <summary>
        /// ���b�Z�[�W��\�����܂��B
        /// </summary>
        /// <param name="infoMessage">�\�����������̕�����</param>
        public void ShowInfoMessageBox(string infoMessage)
        {
            if (infoMessage != null)
            {
                MessageBox.Show(infoMessage, "MELFA Cloud Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W��\�����܂��B
        /// </summary>
        /// <param name="errorModel">�\���������G���[�̏��</param>
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