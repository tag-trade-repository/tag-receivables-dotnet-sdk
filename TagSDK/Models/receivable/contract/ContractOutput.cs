using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
