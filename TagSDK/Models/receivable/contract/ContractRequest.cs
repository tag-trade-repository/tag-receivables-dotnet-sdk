using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractRequest
    {
        [JsonProperty("contracts")]
        public List<Contract> Contracts { get; set; }
    }
}
