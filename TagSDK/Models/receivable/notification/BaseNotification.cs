using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public abstract class BaseNotification
    {
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("hasError")]
        public bool HasError { get; set; }
    }
}
