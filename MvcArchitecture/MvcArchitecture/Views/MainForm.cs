using MvcArchitecture.Controllers;
using MvcArchitecture.Models;

namespace MvcArchitecture.Views
{
    public partial class MainForm : Form
    {
        private MainFormController _mainFormController;

        public MainForm(MainFormController mainFormController)
        {
            InitializeComponent();
            _mainFormController = mainFormController;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            _mainFormController.UpdateText();
        }

        public void UpdateText(string newText)
        {
            TestTextBox.Text = newText;
        }

        public void ShowMessageBox(MessageModel message)
        {
            if (message != null)
            {
                MessageBox.Show(message.Message, message.Title, message.Button, message.Icon);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = string.Format("Are you sure you want to close?");
            if (MessageBox.Show(msg, Constants.SoftwareName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                e.Cancel = true;
            }
        }
    }
}