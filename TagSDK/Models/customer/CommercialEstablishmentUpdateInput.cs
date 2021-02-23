using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace TagSDK.Models.Customer
{
    public class CommercialEstablishmentUpdateInput
    {
        [JsonProperty("paymentSchemes")]
        public List<string> PaymentSchemes { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
