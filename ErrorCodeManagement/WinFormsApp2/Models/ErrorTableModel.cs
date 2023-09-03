namespace WinFormsApp2.Models
{
    /// <summary>
    /// エラー一覧を定義するためのクラスです。
    /// </summary>
    public class ErrorTableModel
    {
        private List<ErrorModel> errorList;

        public ErrorTableModel()
        {
            errorList = new List<ErrorModel>
            {
                new ErrorModel { code = 1000, message = "IP address is invalid. (Error Code: 1000)", button = MessageBoxButtons.OK, icon = MessageBoxIcon.Warning },
                new ErrorModel { code = 1001, message = "Port number should be between 1 to 65535. (Error Code: 1001)", button = MessageBoxButtons.OK, icon = MessageBoxIcon.Warning },
            };
        }

        public ErrorModel GetErrorInfo(int errorCode)
        {
            return errorList.Find(error => error.code == errorCode);
        }
    }
}
