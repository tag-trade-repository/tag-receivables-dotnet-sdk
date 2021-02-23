using Newtonsoft.Json;

namespace TagSDK.Models.Response
{
    public class BasePaginatedQueryResponse : BaseQueryResponse
    {
        [JsonProperty("pages")]
        public PagesOutput Pages { get; set; }
    }
}
