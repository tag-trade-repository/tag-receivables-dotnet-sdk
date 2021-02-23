using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Response
{
    public class BaseQueryResponse
    {
        [JsonProperty("queryKey")]
        public string QueryKey { get; set; }

        [JsonProperty("queryDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? QueryDate { get; set; }
    }
}
