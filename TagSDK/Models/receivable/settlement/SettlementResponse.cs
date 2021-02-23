using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementResponse : BaseResponse
    {
        [JsonProperty("settlements")]
        public List<SettlementDetail> Settlements { get; set; }
    }
}
