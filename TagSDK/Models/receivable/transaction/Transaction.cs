using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Transaction
{
    public class Transaction
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("transactionDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? DueDate { get; set; }
    }
}
