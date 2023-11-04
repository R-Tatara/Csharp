namespace ReadWriteJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonManage jsonManage = new JsonManage();

            jsonManage.WriteSettingFile();
            jsonManage.ReadSettingFile();
        }
    }
}