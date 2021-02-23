using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractSpecification
    {
        [JsonProperty("expectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExpectedSettlementDate { get; set; }

        [JsonProperty("originalAssetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType OriginalAssetHolderDocumentType { get; set; }

        [JsonProperty("originalAssetHolder")]
        public string OriginalAssetHolder { get; set; }

        [JsonProperty("receivableDebtor")]
        public string ReceivableDebtor { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("effectValue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal EffectValue { get; set; }
    }
}
