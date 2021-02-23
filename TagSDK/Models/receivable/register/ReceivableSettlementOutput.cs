using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Register
{
    public class ReceivableSettlementOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
