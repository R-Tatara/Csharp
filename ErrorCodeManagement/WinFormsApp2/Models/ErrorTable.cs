namespace WinFormsApp2.Models
{
    /// <summary>
    /// エラー一覧を定義するためのクラスです。
    /// </summary>
    public class ErrorTable
    {
        private List<ErrorModel> errorList;

        public ErrorTable()
        {
            errorList = new List<ErrorModel>
            {
                new ErrorModel { code = 1000, message = "Port number should be between 1 to 65535. (Code: 1000)", button = MessageBoxButtons.OK, icon = MessageBoxIcon.Warning },
            };
        }

        public ErrorModel? GetErrorInfo(int errorCode)
        {
            return errorList.Find(error => error.code == errorCode);
        }
    }
}
