using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button1_Click start");
            int ret = await Task.Run( () => Task1Async() );
            Debug.WriteLine("button1_Click end");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button2_Click start");
            int ret = await Task.Run( () => Task2Async() );
            Debug.WriteLine("button2_Click end");
        }

        private async Task<int> Task1Async()
        {
            Debug.WriteLine("Task1Async start");
            await Task.Delay(2000);
            Debug.WriteLine("Task1Async end");
            return 0;
        }

        private async Task<int> Task2Async()
        {
            Debug.WriteLine("Task2Async start");
            await Task.Delay(2000);
            Debug.WriteLine("Task2Async end");
            return 0;
        }
    }
}
