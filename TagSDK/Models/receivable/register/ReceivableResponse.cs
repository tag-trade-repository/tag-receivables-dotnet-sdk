using System.Collections.Generic;
using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Register
{
    public class ReceivableResponse : BaseResponse
    {
        [JsonProperty("receivables")]
        public List<ReceivableOutput> Receivables { get; set; }
    }
}
