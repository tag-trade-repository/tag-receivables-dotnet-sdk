using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Reconciliation
{
    public class ReconciliationConfirmationRequest
    {
        [JsonProperty("reconciliationkey")]
        public string ReconciliationKey { get; set; }
    }
}
