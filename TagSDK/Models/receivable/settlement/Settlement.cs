using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Settlement
{
    public class Settlement
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("settlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? SettlementDate { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("settlementObligationDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? SettlementObligationDate { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

    }
}
