using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationContractInfo
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("isCanceled")]
        public bool IsCanceled { get; set; }

        [JsonProperty("contractDueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? ContractDueDate { get; set; }

        [JsonProperty("contractHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType ContractHolderDocumentType { get; set; }

        [JsonProperty("contractHolder")]
        public string ContractHolder { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("contractUniqueIdentifier")]
        public string ContractUniqueIdentifier { get; set; }

        [JsonProperty("signatureDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? SignatureDate { get; set; }

        [JsonProperty("effectType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectType EffectType { get; set; }

        [JsonProperty("warrantyType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WarrantyType WarrantyType { get; set; }

        [JsonProperty("warrantyAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal WarrantyAmount { get; set; }

        [JsonProperty("balanceDue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal BalanceDue { get; set; }

        [JsonProperty("divisionMethod")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DivisionMethodType DivisionMethod { get; set; }

        [JsonProperty("percentageValue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal PercentageValue { get; set; }

        [JsonProperty("effectStrategy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectStrategy EffectStrategy { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("settlementExpectationAffected")]
        public List<NotificationSettlementExpectationAffected> NotificationSettlementExpectationAffected { get; set; }

    }
}
