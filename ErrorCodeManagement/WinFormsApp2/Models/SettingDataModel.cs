using Newtonsoft.Json;

namespace WinFormsApp2.Models
{
    /// <summary>
    /// Jsonファイルのキーの一覧を定義しています。
    /// </summary>
    [JsonObject("configjson")]
    public sealed class ConfigKeyList
    {
        [JsonProperty("network")]
        public NetworkKeyList? network { get; set; }

        [JsonProperty("filepath")]
        public string filepath { get; set; } = "";
    }

    /// <summary>
    /// Jsonファイルの"network"キー内のキーの一覧を定義しています。
    /// </summary>
    [JsonObject("networkjson")]
    public sealed class NetworkKeyList
    {
        [JsonProperty("ipaddr")]
        public string ipAddr { get; set; } = "";

        [JsonProperty("port")]
        public int port { get; set; }
    }

}
