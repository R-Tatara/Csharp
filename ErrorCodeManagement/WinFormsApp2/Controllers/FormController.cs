using WinFormsApp2.Models;

namespace WinFormsApp2.Controllers
{
    internal class FormController
    {
        private Form1 form1;
        private SettingFileModel jsonIO;

        public FormController(Form1 form)
        {
            jsonIO = new SettingFileModel();
            form1 = form;
        }

        /// <summary>
        /// 設定ファイルを読み出します。
        /// </summary>
        public void LoadSettingFile()
        {
            jsonIO.LoadSettingFile();
        }

        /// <summary>
        /// 設定ファイルを保存します。
        /// </summary>
        public void SaveSettingFile()
        {
            jsonIO.SaveSettingFile();
        }

        /// <summary>
        /// 設定データのポート番号を更新します。
        /// ポート番号が範囲外の場合、エラーメッセージを表示します。
        /// </summary>
        /// <param name="newPort">変更後のポート番号</param>
        public void UpdateNetworkPort(int newPort)
        {
            if (jsonIO.UpdateNetworkPort(newPort) == false)
            {
                form1.ShowErrorMessageBox(1000);
            }
        }
    }
}
