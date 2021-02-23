using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentPaginatedQueryResponse : BaseResponse
    {
        [JsonProperty("commercialEstablishments")]
        public List<CommercialEstablishmentQueryOutput> CommercialEstablishments { get; set; }

        [JsonProperty("pages")]
        public PagesOutput Pages { get; set; }
    }
}
