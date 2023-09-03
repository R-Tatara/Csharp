using WinFormsApp2.Models;

namespace WinFormsApp2.Controllers
{
    internal class FormController
    {
        private SettingManageModel settingManageModel;
        private ErrorTableModel errorTableModel;
        private Form1 form1;

        public FormController(Form1 form)
        {
            settingManageModel = new SettingManageModel();
            errorTableModel = new ErrorTableModel();
            form1 = form;
        }

        /// <summary>
        /// 設定ファイルを読み出します。
        /// </summary>
        public void LoadSettingFile()
        {
            if (settingManageModel.ReadSettingFile() == false) 
            {
                ShowErrorMessageBox(1000);
                //[TODO]setting.jsonの復旧処理が必要
            }
        }

        /// <summary>
        /// 設定ファイルを保存します。
        /// </summary>
        public void SaveSettingFile()
        {
            if (settingManageModel.WriteSettingFile() == false) 
            {
                ShowErrorMessageBox(1000);
                //[TODO]setting.jsonの復旧処理が必要？
            }
        }

        /// <summary>
        /// R2プロトコルサーバのIPアドレス、ポート番号を更新します。
        /// 異常な値の場合は、エラーメッセージを表示します。
        /// </summary>
        /// <param name="newIp">変更後のIPアドレス</param>
        /// <param name="newPort">変更後のポート番号</param>
        public void UpdateR2sInfo(string newIp, int newPort)
        {
            if (settingManageModel.IsValidIp(newIp) == false) 
            {
                ShowErrorMessageBox(1000);
                return;
            }

            if (settingManageModel.IsValidPort(newPort) == false) 
            {
                ShowErrorMessageBox(1001);
                return;
            }

            settingManageModel.UpdateR2sInfo(newIp, newPort);
            form1.ShowInfoMessageBox("Updated network information successflly.");
        }

        /// <summary>
        /// 指定したエラー番号のメッセージボックスを表示します。
        /// </summary>
        /// <param name="errorNum">エラー番号</param>
        private void ShowErrorMessageBox(int errorNum)
        {
            //[TODO]エラー番号登録漏れの場合
            ErrorModel errorModel = errorTableModel.GetErrorInfo(errorNum);
            if (errorModel != null)
            {
                form1.ShowErrorMessageBox(errorModel);
            }
            else
            {
                throw new Exception("Not found error number. (Error Code: 100)");
            }
        }

        public void AddNewRc(string newRc, int newPort)
        {
            settingManageModel.AddNewRc(newRc, newPort);
            //[TODO]エラーチェック
        }

        public void UpdateRcInfo(int index, string newIp, int newPort)
        {
            settingManageModel.UpdateRcInfo(index, newIp, newPort);
            //[TODO]エラーチェック
        }

        public void DeleteRc(int index)
        {
            settingManageModel.DeleteRc(index);
            //[TODO]エラーチェック
        }
    }
}
