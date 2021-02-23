using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentReject
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
