using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models
{
    public class BankAccount
    {
        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("accountDigit")]
        public string AccountDigit { get; set; }

        [JsonProperty("accountType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType AccountType { get; set; }

        [JsonProperty("ispb")]
        public string Ispb { get; set; }

        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType DocumentType { get; set; }

        [JsonProperty("documentNumber")]
        public string DocumentNumber { get; set; }
    }
}
