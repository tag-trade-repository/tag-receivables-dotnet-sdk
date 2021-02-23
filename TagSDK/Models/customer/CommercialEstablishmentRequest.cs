using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentRequest
    {
        [JsonProperty("commercialEstablishments")]
        public List<CommercialEstablishment> CommercialEstablishments { get; set; }
    }
}
