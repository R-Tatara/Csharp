namespace MvcArchitecture.Controllers
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            MainFormController _mainFormController = new MainFormController();
        }
    }
}