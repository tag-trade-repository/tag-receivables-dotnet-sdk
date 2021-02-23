using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementRequest
    {
        [JsonProperty("settlements")]
        public List<Settlement> Settlements { get; set; }
    }
}
