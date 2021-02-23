using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Response
{
    public class BaseResponse
    {
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }
    }
}
