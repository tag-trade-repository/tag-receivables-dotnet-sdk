using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionExpectationQueryOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("totalAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal TotalAmount { get; set; }

        [JsonProperty("settledAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal SettledAmount { get; set; }

        [JsonProperty("balanceAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal BalanceAmount { get; set; }

        [JsonProperty("committedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal CommittedAmount { get; set; }

        [JsonProperty("uncommittedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal UncommittedAmount { get; set; }

        [JsonProperty("expectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExpectedSettlementDate { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSSSS'Z'")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("settlementObligations")]
        public List<PositionSettlementObligation> SettlementObligations { get; set; }
    }
}
