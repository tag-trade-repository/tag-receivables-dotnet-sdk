using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionContractObligations
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("contractHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType ContractHolderDocumentType { get; set; }

        [JsonProperty("contractHolder")]
        public string ContractHolder { get; set; }

        [JsonProperty("effectPriority")]
        public int EffectPriority { get; set; }

        [JsonProperty("contractType")]
        public string ContractType { get; set; }

        [JsonProperty("warrantyType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WarrantyType WarrantyType { get; set; }

        [JsonProperty("divisionMethod")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DivisionMethodType DivisionMethod { get; set; }

        [JsonProperty("effectStrategy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectStrategy EffectStrategy { get; set; }

        [JsonProperty("effectAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal EffectAmount { get; set; }

        [JsonProperty("committedEffectAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal CommittedEffectAmount { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSSSS'Z'")]
        public DateTime? LastUpdate { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSSSS'Z'")]
        public DateTime? CreatedAt { get; set; }
    }
}
