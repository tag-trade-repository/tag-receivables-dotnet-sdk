using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentResponse : BaseResponse
    {
        [JsonProperty("commercialEstablishments")]
        public List<CommercialEstablishmentOutput> CommercialEstablishments { get; set; }
    }
}
