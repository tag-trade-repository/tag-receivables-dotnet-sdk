using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Register
{
    public class ReceivableRequest
    {
        [JsonProperty("processReference")]
        public string ProcessReference { get; set; }

        [JsonProperty("receivables")]
        public List<Receivable> Receivables { get; set; }
    }
}
