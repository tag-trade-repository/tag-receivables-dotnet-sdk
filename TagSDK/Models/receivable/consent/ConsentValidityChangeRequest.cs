using System;
using Newtonsoft.Json;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentValidityChangeRequest
    {
        [JsonProperty("startDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? EndDate { get; set; }
    }
}
