using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonFileIO.Jsons
{
    [JsonObject("configjson")]
    public sealed class ConfigJson
    {
        [JsonProperty("network")]
        public NetworkJson network { get; set; }

        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }

    [JsonObject("networkjson")]
    public sealed class NetworkJson
    {
        [JsonProperty("ipaddr")]
        public string ipAddr { get; set; }

        [JsonProperty("port")]
        public int port { get; set; }
    }
}
