using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Notification
{
    public class NotificationContractEffect
    {
        [JsonProperty("effectStrategy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectStrategy EffectStrategy { get; set; }

        [JsonProperty("divisionMethod")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DivisionMethodType DivisionMethod { get; set; }

        [JsonProperty("effectType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EffectType EffectType { get; set; }

        [JsonProperty("effectAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal EffectAmount { get; set; }

        [JsonProperty("committedAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal CommittedAmount { get; set; }

        [JsonProperty("percentageValue")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal PercentageValue { get; set; }

        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("effectPriority")]
        public int EffectPriority { get; set; }
    }
}
