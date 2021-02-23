using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractPaginatedQueryResponse : BasePaginatedQueryResponse
    {
        [JsonProperty("contracts")]
        public List<ContractQueryOutput> Contracts { get; set; }
    }
}
