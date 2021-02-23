using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementDetail
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
