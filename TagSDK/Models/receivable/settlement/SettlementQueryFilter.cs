using System;
using System.ComponentModel;

namespace TagSDK.Models.Receivable.Settlement
{
    public class SettlementQueryFilter
    {
        [DisplayName("startSettlementDate")]
        public DateTime? StartSettlementDate { get; set; }

        [DisplayName("endSettlementDate")]
        public DateTime? EndSettlementDate { get; set; }

        [DisplayName("paymentScheme")]
        public string PaymentScheme { get; set; }

        [DisplayName("assetHolder")]
        public string AssetHolder { get; set; }
    }
}
