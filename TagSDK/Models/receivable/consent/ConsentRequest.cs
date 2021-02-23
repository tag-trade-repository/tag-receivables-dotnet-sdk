using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentRequest
    {
        [JsonProperty("optIns")]
        public List<Consent> OptIns { get; set; }
    }
}
