using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Models.Response;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Reconciliation
{
    public class ReconciliationQueryResponse : BaseResponse
    {
        [JsonProperty("reconciliationKey")]
        public string ReconciliationKey { get; set; }

        [JsonProperty("extractionReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExtractionReferenceDate { get; set; }

        [JsonProperty("recipientDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType RecipientDocumentType { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("reconciliationStatus")]
        public string ReconciliationStatus { get; set; }

        [JsonProperty("urls")]
        public List<string> Urls { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }
    }
}
