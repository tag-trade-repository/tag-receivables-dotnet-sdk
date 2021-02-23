using System.ComponentModel;

namespace TagSDK.Models.Request
{
    public class Pagination
    {
        [DisplayName("perPage")]
        public int Limit { get; set; }
        [DisplayName("page")]
        public int Page { get; set; }
    }
}
