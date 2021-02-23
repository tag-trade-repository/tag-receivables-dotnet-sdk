using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationConsent
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("consentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentType ConsentType { get; set; }

        [JsonProperty("consentStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsentStatus ConsentStatus { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("requester")]
        public string Requester { get; set; }

        [JsonProperty("beneficiary")]
        public string Beneficiary { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("signatureDate")]
        public string SignatureDate { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }
    }
}
