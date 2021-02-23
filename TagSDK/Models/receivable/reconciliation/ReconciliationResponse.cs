using System;
using Newtonsoft.Json;
using TagSDK.Models.Response;
using TagSDK.Utils;


namespace TagSDK.Models.Receivable.Reconciliation
{
    public class ReconciliationResponse : BaseResponse
    {
        [JsonProperty("reconciliationKey")]
        public string ReconciliationKey { get; set; }

        [JsonProperty("reconciliationStatus")]
        public string ReconciliationStatus { get; set; }

        [JsonProperty("extractionReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExtractionReferenceDate { get; set; }
    }
}
