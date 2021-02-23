using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentQueryOutput : Consent
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("requester")]
        public string Requester { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("consentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentType ConsentType { get; set; }

        [JsonProperty("reject")]
        public bool Reject { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentStatus Status { get; set; }

        [JsonProperty("updatedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? UpdatedDate { get; set; }
    }
}
