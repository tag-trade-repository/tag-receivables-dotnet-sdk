using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentQueryOutput
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("paymentSchemes")]
        public List<string> PaymentSchemes { get; set; }

        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType DocumentType { get; set; }

        [JsonProperty("documentNumber")]
        public string DocumentNumber { get; set; }
    }
}
