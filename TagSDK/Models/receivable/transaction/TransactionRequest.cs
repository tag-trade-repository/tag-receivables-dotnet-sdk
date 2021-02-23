using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Transaction
{
    public class TransactionRequest
    {
        [JsonProperty("receivables")]
        public List<TransactionReceivable> Receivables { get; set; }
    }
}
