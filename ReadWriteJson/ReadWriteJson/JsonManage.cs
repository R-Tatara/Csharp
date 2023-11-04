using System.Text;
using Newtonsoft.Json;

namespace ReadWriteJson
{
    public class JsonManage
    {
        JsonData _jsonData = new JsonData
        {
            MachineList = new List<MachineList>
            {
                new MachineList
                {
                    SerialNumber = "ABC0001",
                    IpAddress = "127.0.0.1"
                }
            },
            IsEnable = true
        };

        public bool WriteSettingFile()
        {
            try
            {
                //Serialize from object to json
                var jsonWriteData = JsonConvert.SerializeObject(_jsonData, Formatting.Indented);

                //Write JSON file (Overwrite mode)
                using (var sw = new StreamWriter(Constants.FileName, false, Encoding.UTF8))
                {
                    sw.Write(jsonWriteData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ReadSettingFile()
        {
            try
            {
                using (var sr = new StreamReader(Constants.FileName, Encoding.UTF8))
                {
                    var jsonReadData = sr.ReadToEnd();

                    //Deserialize from json to object
                    _jsonData = JsonConvert.DeserializeObject<JsonData>(jsonReadData);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
