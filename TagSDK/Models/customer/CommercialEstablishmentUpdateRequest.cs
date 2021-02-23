using System.Text.Json;
using Newtonsoft.Json;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentUpdateRequest
    {
        [JsonProperty("commercialEstablishments")]
        public CommercialEstablishmentUpdateInput CommercialEstablishment { get; set; }
    }
}
