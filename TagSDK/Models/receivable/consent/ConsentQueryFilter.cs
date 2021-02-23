using System;
using System.ComponentModel;

namespace TagSDK.Models.Receivable.Consent
{
    public class ConsentQueryFilter
    {
        [DisplayName("assetHolder")]
        public string AssetHolder { get; set; }

        [DisplayName("beneficiary")]
        public string Beneficiary { get; set; }

        [DisplayName("acquirer")]
        public string Acquirer { get; set; }

        [DisplayName("paymentScheme")]
        public string PaymentScheme { get; set; }

        [DisplayName("initialDate")]
        public DateTime? InitialDate { get; set; }

        [DisplayName("finalDate")]
        public DateTime? FinalDate { get; set; }
    }
}
