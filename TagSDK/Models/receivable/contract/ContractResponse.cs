using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractResponse : BaseResponse
    {
        [JsonProperty("contracts")]
        public List<ContractOutput> Contracts { get; set; }

    }
}
