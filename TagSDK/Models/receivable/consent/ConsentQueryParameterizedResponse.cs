
using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentQueryParameterizedResponse : BaseResponse
    {
        [JsonProperty("optIns")]
        public List<ConsentQueryOutput> OptIns { get; set; }
    }
}
