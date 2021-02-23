using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationSettlementExpectationAffected
    {
        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("expectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? ExpectedSettlementDate { get; set; }

        [JsonProperty("totalAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal TotalAmount { get; set; }

        [JsonProperty("settledAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal SettledAmount { get; set; }

        [JsonProperty("balanceAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal BalanceAmount { get; set; }

        [JsonProperty("committedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal CommittedAmount { get; set; }

        [JsonProperty("uncommittedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal UncommittedAmount { get; set; }

        [JsonProperty("contractEffects")]
        public List<NotificationContractEffect> NotificationContractEffects { get; set; }
    }
}
