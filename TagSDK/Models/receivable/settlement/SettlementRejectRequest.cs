using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementRejectRequest
    {
        [JsonProperty("settlements")]
        public List<SettlementReject> Settlements { get; set; }
    }
}
