using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementReject
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reasonDetails")]
        public string ReasonDetails { get; set; }
    }
}
