using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishment
    {
        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType DocumentType { get; set; }

        [JsonProperty("documentNumber")]
        public string DocumentNumber { get; set; }

        [JsonProperty("paymentSchemes")]
        public List<string> PaymentSchemes { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }
    }
}
