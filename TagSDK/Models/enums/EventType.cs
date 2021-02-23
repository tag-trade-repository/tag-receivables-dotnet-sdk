using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum EventType
    {
        [EnumMember(Value = "settlement")]
        SETTLEMENT,
        [EnumMember(Value = "consent")]
        CONSENT,
        [EnumMember(Value = "settlementreject")]
        SETTLEMENTREJECT,
        [EnumMember(Value = "advacement")]
        ADVANCEMENT,
        [EnumMember(Value = "debtor")]
        DEBTOR,
        [EnumMember(Value = "position")]
        POSITION,
        [EnumMember(Value = "contract")]
        CONTRACT
    }
}
