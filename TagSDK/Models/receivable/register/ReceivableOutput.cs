using System;
using System.Collections.Generic;
using TagSDK.Utils;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Register
{
    public class ReceivableOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("originalAssetHolder")]
        public string OriginalAssetHolder { get; set; }

        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("settlements")]
        public List<ReceivableSettlementOutput> Settlements { get; set; }
    }
}
