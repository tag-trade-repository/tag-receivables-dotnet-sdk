using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationSettlementReject : BaseNotification
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("debtor")]
        public string Debtor { get; set; }

        [JsonProperty("reasonDetails")]
        public string ReasonDetails { get; set; }
    }
}
