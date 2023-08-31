using System.Text;
using Newtonsoft.Json;

namespace WinFormsApp2.Models
{
    /// <summary>
    /// 設定ファイルを管理するためのクラスです。
    /// </summary>
    internal class SettingManageModel
    {
        ConfigKeyList? config;

        public SettingManageModel()
        {
            config = new ConfigKeyList();
        }

        //[TODO]jsonファイルが存在しない場合
        //[TODO]項目が不足している場合のnullチェック
        public void ReadSettingFile()
        {
            using (var sr = new StreamReader(@".\sample.json", Encoding.UTF8))
            {
                var jsonReadData = sr.ReadToEnd();

                //Deserialize from json to object
                config = JsonConvert.DeserializeObject<ConfigKeyList>(jsonReadData);
            }
        }

        //[TODO]jsonファイルが他プロセスによってオープンされていた場合
        public void WriteSettingFile()
        {
            //Serialize from object to json
            var jsonWriteData = JsonConvert.SerializeObject(config, Formatting.Indented);

            //Write JSON file
            //[TODO]ファイル名のハードコーディングを解消
            using (var sw = new StreamWriter(@".\sample.json", false, Encoding.UTF8)) //Overwrite mode
            {
                sw.Write(jsonWriteData);
            }
        }

        public bool UpdateR2sPort(int newNum)
        {
            //[TODO]マジックナンバーの置き換え
            if (newNum >= 1 && newNum <= 65535)
            {
                config.server.port = newNum;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
