using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Transaction
{
    public class TransactionQueryResponse : BaseResponse
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> ReceivableTransactionItems { get; set; }
    }
}
