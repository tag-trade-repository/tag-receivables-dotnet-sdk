using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Advancement
{
    public class Advancement
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("operationValue")]

        [JsonConverter(typeof(CustomSerializer))]
        public decimal OperationValue { get; set; }

        [JsonProperty("operationExpectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? OperationExpectedSettlementDate { get; set; }

        [JsonProperty("advancedReceivables")]
        public List<AdvancedReceivable> AdvancedReceivables { get; set; }
    }
}
