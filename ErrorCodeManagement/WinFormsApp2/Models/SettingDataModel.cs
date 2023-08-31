using Newtonsoft.Json;

namespace WinFormsApp2.Models
{
    /// <summary>
    /// 設定ファイルのキーの一覧を定義しています。
    /// </summary>
    public sealed class ConfigKeyList
    {
        [JsonProperty("robotControllerList")]
        public RobotControllerListKeyList[] robotControllerList { get; set; }

        [JsonProperty("server")]
        public ServerKeyList server { get; set; }

        [JsonProperty("collecter")]
        public CollecterKeyList collecter { get; set; }

        [JsonProperty("others")]
        public OthersKeyList others { get; set; }
    }

    /// <summary>
    /// 設定ファイルの"rclist"キー内のキーの一覧を定義しています。
    /// </summary>
    public sealed class RobotControllerListKeyList
    {
        [JsonProperty("rcserial")]
        public string rcserial { get; set; } = "";

        [JsonProperty("ip")]
        public string ip { get; set; } = "";

        [JsonProperty("port")]
        public int port { get; set; }
    }

    /// <summary>
    /// 設定ファイルの"server"キー内のキーの一覧を定義しています。
    /// </summary>
    public sealed class ServerKeyList
    {
        [JsonProperty("ip")]
        public string ip { get; set; } = "";

        [JsonProperty("port")]
        public int port { get; set; }
    }

    /// <summary>
    /// 設定ファイルの"collecter"キー内のキーの一覧を定義しています。
    /// </summary>
    public sealed class CollecterKeyList
    {
        [JsonProperty("shortPeriod")]
        public int shortPeriod { get; set; }

        [JsonProperty("longPeriod")]
        public int longPeriod { get; set; }
    }

    /// <summary>
    /// 設定ファイルの"others"キー内のキーの一覧を定義しています。
    /// </summary>
    public sealed class OthersKeyList
    {
        [JsonProperty("ignoreMssts")]
        public int ignoredMssts { get; set; }
    }
}
