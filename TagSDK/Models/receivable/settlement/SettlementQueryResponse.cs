using Newtonsoft.Json;
using TagSDK.Models.Response;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementQueryResponse : BaseQueryResponse
    {
        [JsonProperty("settlement")]
        public SettlementQueryOutput Settlement { get; set; }
    }
}
