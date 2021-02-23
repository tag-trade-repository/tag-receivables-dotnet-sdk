using Newtonsoft.Json;

namespace TagSDK.Models.Response
{
    public class PagesOutput
    {
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("perPage")]
        public int PerPage { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}
