using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionReceivablesQueryOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("originalAssetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType OriginalAssetHolderDocumentType { get; set; }

        [JsonProperty("originalAssetHolder")]
        public string OriginalAssetHolder { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("prePaidAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal PrePaidAmount { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("settlementObligations")]
        public List<PositionSettlementObligation> SettlementObligations { get; set; }
    }
}
