using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentResponse : BaseResponse
    {
        [JsonProperty("optIns")]
        public List<ConsentOutput> ConsentOutputs { get; set; }
    }
}
