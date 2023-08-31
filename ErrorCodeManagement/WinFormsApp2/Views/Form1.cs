using WinFormsApp2.Controllers;
using WinFormsApp2.Models;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private FormController formController;

        public Form1()
        {
            InitializeComponent();
            formController = new FormController(this);
        }

        /// <summary>
        /// フォームがロードされたときのイベントです。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //formController.LoadSettingFile();
        }

        /// <summary>
        /// フォームがクローズされたときのイベントです。
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formController.SaveSettingFile();
        }

        /// <summary>
        /// ボタンがクリックされたときのイベントです。
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //formController.UpdateR2sPort(76543);

            ConfigKeyList configKeyList = new ConfigKeyList
            {
                robotControllerList = new RobotControllerListKeyList[2]
                {
                    new RobotControllerListKeyList
                    {
                        rcserial = "BB1010001R",
                        ip = "192.168.0.20",
                        port = 10005
                    },
                    new RobotControllerListKeyList
                    {
                        rcserial = "BB1010002R",
                        ip = "192.168.0.21",
                        port = 10005
                    }
                },
                server = new ServerKeyList
                {
                    ip = "192.168.0.100",
                    port = 8888
                },
                collecter = new CollecterKeyList
                {
                    shortPeriod = 2,
                    longPeriod = 3600
                },
                others = new OthersKeyList
                {
                    ignoredMssts = 0
                }
            };

            //Serialize from object to json
            var jsonWriteData = JsonConvert.SerializeObject(configKeyList, Formatting.Indented);

            //Write JSON file
            using (var sw = new StreamWriter(@".\sample.json", false, System.Text.Encoding.UTF8)) //Overwrite mode
            {
                sw.Write(jsonWriteData);
            }
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="errorModel">表示したいエラーの情報</param>
        public void ShowErrorMessageBox(ErrorModel errorModel)
        {
            if (errorModel != null)
            {
                MessageBox.Show(errorModel.message, errorModel.title, errorModel.button, errorModel.icon);
            }
        }
    }
}