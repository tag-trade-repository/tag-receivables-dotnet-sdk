using System;
using Newtonsoft.Json;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Consent
{
    public class Consent
    {
        [JsonProperty("beneficiary")]
        public string Beneficiary { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("signatureDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? SignatureDate { get; set; }

        [JsonProperty("startDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? EndDate { get; set; }
    }
}
