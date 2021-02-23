using System;
using Newtonsoft.Json;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Reconciliation
{
    public class ReconciliationRequest
    {
        [JsonProperty("reconciliationDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ReconciliationDate { get; set; }
    }
}
