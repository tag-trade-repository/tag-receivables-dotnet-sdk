using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Errors
{
    public class ResponseError
    {
        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("error")]
        private List<string> AltErrors { set => Errors = value; }

        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("processkey")]
        private string AltProcessKey { set => ProcessKey = value; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'")]
        private DateTime? AltCreatedAt { set => CreatedAt = value; }
    }
}
