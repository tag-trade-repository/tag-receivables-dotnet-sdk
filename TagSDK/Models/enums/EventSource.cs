using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum EventSource
    {
        [EnumMember(Value = "ContractHolder")]
        CONTRACTHOLDER,
        [EnumMember(Value = "TradeRepository")]
        TRADEREPOSITORY
    }
}
