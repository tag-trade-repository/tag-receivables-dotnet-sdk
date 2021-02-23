using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Models.Response;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionExpectationQueryResponse : BaseResponse
    {
        [JsonProperty("settlementExpectations")]
        public List<PositionExpectationQueryOutput> SettlementExpectations { get; set; }

        [JsonProperty("extractionReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExtractionReferenceDate { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("recipientDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType RecipientDocumentType { get; set; }
    }
}
