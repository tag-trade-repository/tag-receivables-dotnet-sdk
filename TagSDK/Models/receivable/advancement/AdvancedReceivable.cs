using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Advancement
{
    public class AdvancedReceivable
    {
        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("settlementObligationDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? SettlementObligationDate { get; set; }

        [JsonProperty("advancedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal AdvancedAmount { get; set; }
    }
}
