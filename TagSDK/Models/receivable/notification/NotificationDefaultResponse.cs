using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationDefaultResponse<T> : BaseResponse
    {
        [JsonProperty("eventType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
