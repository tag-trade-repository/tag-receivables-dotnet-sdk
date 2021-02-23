using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Response;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionReceivablesQueryResponse : BaseResponse
    {
        [JsonProperty("receivables")]
        public List<PositionReceivablesQueryOutput> Receivables { get; set; }

        [JsonProperty("extractionReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? ExtractionReferenceDate { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("recipientDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType RecipientDocumentType { get; set; }
    }
}
