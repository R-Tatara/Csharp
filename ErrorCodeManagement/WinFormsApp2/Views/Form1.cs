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
            formController.UpdateR2sPort(76543);
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
    }
}