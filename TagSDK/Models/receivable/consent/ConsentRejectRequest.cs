using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentRejectRequest
    {
        [JsonProperty("optIns")]
        public List<ConsentReject> OptIns { get; set; }
    }
}
