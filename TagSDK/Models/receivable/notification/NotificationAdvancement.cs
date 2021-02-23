using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationAdvancement : BaseNotification
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("notificationReferenceDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? NotificationReferenceDate { get; set; }

        [JsonProperty("notificationRecipientDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType NotificationRecipientDocumentType { get; set; }

        [JsonProperty("notificationRecipient")]
        public string NotificationRecipient { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("assetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType AssetHolderDocumentType { get; set; }

        [JsonProperty("assetHolder")]
        public string AssetHolder { get; set; }

        [JsonProperty("operationExpectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? OperationExpectedSettlementDate { get; set; }

        [JsonProperty("operationValue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal OperationValue { get; set; }

        [JsonProperty("settlementObligations")]
        public List<NotificationSettlementObligation> NotificationSettlementObligations { get; set; }
    }
}
