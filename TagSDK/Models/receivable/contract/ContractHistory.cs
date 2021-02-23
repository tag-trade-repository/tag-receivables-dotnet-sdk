using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractHistory
    {

        [JsonProperty("contractDueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ContractDueDate { get; set; }

        [JsonProperty("balanceDue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal BalanceDue { get; set; }

        [JsonProperty("contractStatus")]
        public string ContractStatus { get; set; }

        [JsonProperty("reason")]
        public long Reason { get; set; }

        [JsonProperty("reasonDetails")]
        public string ReasonDetails { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? CreatedAt { get; set; }
    }
}
