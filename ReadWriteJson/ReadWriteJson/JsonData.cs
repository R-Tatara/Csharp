using Newtonsoft.Json; // Add "PackageReference" to project file

namespace ReadWriteJson
{
    [JsonObject("json_data")]
    public class JsonData
    {
        [JsonProperty("machine_list")]
        public List<MachineList> MachineList { get; set; }

        [JsonProperty("is_enable")]
        public bool IsEnable { get; set; } = true;
    }

    [JsonObject("machine_list")]
    public class MachineList
    {
        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; } = string.Empty;

        [JsonProperty("ip_address")]
        public string IpAddress{ get; set; } = string.Empty;
    }
}
