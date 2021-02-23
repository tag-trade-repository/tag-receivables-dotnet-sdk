using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementQueryOutput : Settlement
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("isRejected")]
        public bool IsRejected { get; set; }

        [JsonProperty("reasonDetails")]
        public string ReasonDetails { get; set; }

        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }
    }
}
