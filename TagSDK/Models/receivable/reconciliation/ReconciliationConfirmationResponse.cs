using System;
using Newtonsoft.Json;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Reconciliation
{
    public class ReconciliationConfirmationResponse
    {
        [JsonProperty("reconciliationKey")]
        public string ReconciliationKey { get; set; }

        [JsonProperty("reconciliationStatus")]
        public string ReconciliationStatus { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }
    }
}
