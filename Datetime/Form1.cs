using System;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += TimerElapsed; //Add Event Handler
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            label1.Invoke(new Action(() =>
            {
                label1.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }));
        }
    }
}
