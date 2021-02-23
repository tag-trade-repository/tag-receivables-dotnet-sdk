using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationConsentWrapper
    {
        [JsonProperty("consentNotification")]
        public List<NotificationConsent> NotificationConsent { get; set; }
    }
}
