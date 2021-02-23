using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementPaginatedQueryResponse : BasePaginatedQueryResponse
    {
        [JsonProperty("settlements")]
        public List<SettlementQueryOutput> Settlements { get; set; }
    }
}
