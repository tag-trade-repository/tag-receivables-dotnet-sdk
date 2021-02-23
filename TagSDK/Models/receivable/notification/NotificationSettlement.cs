using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Numerics;
using TagSDK.Utils;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationSettlement : BaseNotification
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("participant")]
        public string Participant { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("settlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? SettlementDate { get; set; }

        [JsonProperty("settlementObligationDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? SettlementObligationDate { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }
    }
}
