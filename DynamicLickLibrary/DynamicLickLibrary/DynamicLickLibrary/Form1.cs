namespace DynamicLickLibrary
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("DLLTEST.dll")]
        private static extern int dllfunc1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ret = dllfunc1();
            MessageBox.Show(ret.ToString());
        }
    }
}