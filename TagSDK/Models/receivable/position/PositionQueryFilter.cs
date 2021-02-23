using System;
using System.ComponentModel;
using TagSDK.Utils;
using Newtonsoft.Json;

namespace TagSDK.Models.Receivable.Position
{
    public class PositionQueryFilter
    {
        [DisplayName("paymentScheme")]
        public string PaymentScheme { get; set; }

        [DisplayName("initialExpectedSettlementDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? InitialExpectedSettlementDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        [DisplayName("finalExpectedSettlementDate")]
        public DateTime? FinalExpectedSettlementDate { get; set; }
    }
}
