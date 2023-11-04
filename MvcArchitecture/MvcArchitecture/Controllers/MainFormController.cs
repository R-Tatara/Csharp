using MvcArchitecture.Models;
using MvcArchitecture.Views;

namespace MvcArchitecture.Controllers
{
    public class MainFormController
    {
        private MainForm        _mainForm;
        private DataModel       _dataModel;
        private MessageTable    _messageTable;

        public MainFormController()
        {
            _mainForm       = new MainForm(this);
            _dataModel      = new DataModel();
            _messageTable   = new MessageTable();

            Application.Run(_mainForm);
        }

        public void UpdateText()
        {
            _mainForm.UpdateText(_dataModel.GetText());
            ShowMessageBox(100);
        }
        
        private void ShowMessageBox(int code)
        {
            MessageModel? messageModel = _messageTable.GetMessageInfo(code);
            if (messageModel != null)
            {
                _mainForm.ShowMessageBox(messageModel);
            }
            else
            {
                throw new Exception("Not found error number. (Error Code: 100)");
            }
        }
    }
}
