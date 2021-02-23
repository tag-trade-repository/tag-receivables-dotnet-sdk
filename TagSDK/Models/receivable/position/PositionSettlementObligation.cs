using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionSettlementObligation
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

        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("expectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExpectedSettlementDate { get; set; }

        [JsonProperty("originalHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType OriginalHolderDocumentType { get; set; }

        [JsonProperty("originalAssetHolder")]
        public string OriginalAssetHolder { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSSSS'Z'")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("obligationType")]
        public string ObligationType { get; set; }

        [JsonProperty("settlements")]
        public List<PositionSettlement> Settlements { get; set; }

        [JsonProperty("contractObligations")]
        public List<PositionContractObligations> ContractObligationItems { get; set; }
    }
}
