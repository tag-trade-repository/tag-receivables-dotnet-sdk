using System.Text.Json;
using Newtonsoft.Json;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentOutput : CommercialEstablishment
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
