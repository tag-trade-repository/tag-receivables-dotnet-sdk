using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractQueryOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("isCanceled")]
        public bool IsCanceled { get; set; }

        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("contractDueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ContractDueDate { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("contractUniqueIdentifier")]
        public string ContractUniqueIdentifier { get; set; }

        [JsonProperty("signatureDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
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

        [JsonProperty("effectStrategy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectStrategy EffectStrategy { get; set; }

        [JsonProperty("percentageValue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal PercentageValue { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("contractSpecifications")]
        public List<ContractSpecification> ContractSpecifications { get; set; }
    }
}
