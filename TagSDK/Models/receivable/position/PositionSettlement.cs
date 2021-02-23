using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionSettlement
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("operationType")]
        public string OperationType { get; set; }

        [JsonProperty("settlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? SettlementDate { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("isRejected")]
        public bool IsRejected { get; set; }
    }
}
