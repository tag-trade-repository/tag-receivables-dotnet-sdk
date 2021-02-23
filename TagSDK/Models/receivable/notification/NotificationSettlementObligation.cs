using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationSettlementObligation : BaseNotification
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("totalAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal TotalAmount { get; set; }

        [JsonProperty("committedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal CommittedAmount { get; set; }

        [JsonProperty("uncommittedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal UncommittedAmount { get; set; }

        [JsonProperty("expectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? ExpectedSettlementDate { get; set; }

        [JsonProperty("obligationType")]
        public string ObligationType { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("contractObligations")]
        public List<string> ContractObligations { get; set; }
    }
}
