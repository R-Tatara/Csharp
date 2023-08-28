using WinFormsApp2.Models;

namespace WinFormsApp2.Controllers
{
    internal class FormController
    {
        private Form1 form1;
        private SettingManageModel settingManageModel;
        private ErrorTableModel errorTableModel;

        public FormController(Form1 form)
        {
            settingManageModel = new SettingManageModel();
            form1 = form;
            errorTableModel = new ErrorTableModel();
        }

        /// <summary>
        /// 設定ファイルを読み出します。
        /// </summary>
        public void LoadSettingFile()
        {
            settingManageModel.ReadSettingFile();
        }

        /// <summary>
        /// 設定ファイルを保存します。
        /// </summary>
        public void SaveSettingFile()
        {
            settingManageModel.WriteSettingFile();
        }

        /// <summary>
        /// 設定データのポート番号を更新します。
        /// ポート番号が範囲外の場合、エラーメッセージを表示します。
        /// </summary>
        /// <param name="newPort">変更後のポート番号</param>
        public void UpdateR2sPort(int newPort)
        {
            if (settingManageModel.UpdateR2sPort(newPort) == false)
            {
                ShowErrorMessageBox(1000);
            }
        }

        private void ShowErrorMessageBox(int errorNum)
        {
            //[TODO]エラー番号登録漏れの場合
            ErrorModel errorModel = errorTableModel.GetErrorInfo(errorNum);
            if (errorModel != null)
            {
                form1.ShowErrorMessageBox(errorModel);
            }
        }
    }
}
