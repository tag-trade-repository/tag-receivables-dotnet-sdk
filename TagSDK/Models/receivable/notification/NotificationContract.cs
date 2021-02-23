using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationContract : BaseNotification
    {
        [JsonProperty("notificationReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? NotificationReferenceDate { get; set; }

        [JsonProperty("notificationRecipientDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType NotificationRecipientDocumentType { get; set; }

        [JsonProperty("notificationRecipient")]
        public string NotificationRecipient { get; set; }

        [JsonProperty("contractInfo")]
        public NotificationContractInfo NotificationContractInfo { get; set; }

        [JsonProperty("eventType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationEventType EventType { get; set; }

        [JsonProperty("eventSource")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventSource EventSource { get; set; }
    }
}
