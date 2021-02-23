using System;
using System.Collections.Generic;
using TagSDK.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TagSDK.Models.Enums;

namespace TagSDK.Models.Receivable.Register
{
    public class Receivable
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("originalAssetHolderDocumentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType OriginalAssetHolderDocumentType { get; set; }

        [JsonProperty("originalAssetHolder")]
        public string OriginalAssetHolder { get; set; }

        [JsonProperty("paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal Amount { get; set; }

        [JsonProperty("prePaidAmount")]
        [JsonConverter(typeof(CustomSerializer))]
        public decimal PrePaidAmount { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty("settlements")]
        public List<ReceivableSettlement> Settlements { get; set; }
    }
}
