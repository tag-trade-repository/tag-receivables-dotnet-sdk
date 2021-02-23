using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Transaction
{
    public class TransactionReceivable
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
