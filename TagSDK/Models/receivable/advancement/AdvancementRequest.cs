using System.Collections.Generic;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Advancement
{
    public class AdvancementRequest
    {
        [JsonProperty("advancements")]
        public List<Advancement> Advancements { get; set; }
    }
}
