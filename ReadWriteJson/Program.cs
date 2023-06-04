using System;
using System.IO;
using JsonFileIO.Jsons;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigJson config = new ConfigJson
            {
                network = new NetworkJson
                {
                    ipAddr = "192.168.0.20",
                    port = 8888
                },
                filepath = @".\log"
            };

            //Serialize from object to json
            var jsonWriteData = JsonConvert.SerializeObject(config, Formatting.Indented);

            //Write JSON file
            using (var sw = new StreamWriter(@".\sample.json", false, System.Text.Encoding.UTF8)) //Overwrite mode
            {
                sw.Write(jsonWriteData);
            }

            //Read JSON file
            using (var sr = new StreamReader(@".\sample.json", System.Text.Encoding.UTF8))
            {
                var jsonReadData = sr.ReadToEnd();

                //Deserialize from json to object
                config = JsonConvert.DeserializeObject<ConfigJson>(jsonReadData);
            }

            Console.WriteLine(config.network.ipAddr);
            Console.WriteLine(config.network.port);
            Console.WriteLine(config.filepath);
        }
    }
}
