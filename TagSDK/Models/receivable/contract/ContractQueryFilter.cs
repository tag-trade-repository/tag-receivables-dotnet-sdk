using Newtonsoft.Json;
using System.ComponentModel;
using System;
using TagSDK.Utils;

namespace TagSDK.Models.Receivable.Contract
{
    public class ContractQueryFilter
    {
        [DisplayName("startContractDueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? StartContractDueDate { get; set; } = null;

        [DisplayName("endContractDueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? EndContractDueDate { get; set; } = null;

        [DisplayName("contractDebtor")]
        public string ContractDebtor { get; set; }

        [DisplayName("startSignatureDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? StartSignatureDate { get; set; } = null;

        [DisplayName("endSignatureDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? EndSignatureDate { get; set; } = null;

        [DisplayName("startCreatedAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? StartCreatedAt { get; set; } = null;

        [DisplayName("endCreatedAt")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? EndCreatedAt { get; set; } = null;

        [DisplayName("assetHolder")]
        public string AssetHolder { get; set; }
    }
}
