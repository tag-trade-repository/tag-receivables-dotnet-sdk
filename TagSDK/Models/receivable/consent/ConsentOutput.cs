using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentOutput : Consent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("requester")]
        public string Requester { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("reject")]
        public bool Reject { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentStatus Status { get; set; }

        [JsonProperty("consentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentType ConsentType { get; set; }
    }
}
