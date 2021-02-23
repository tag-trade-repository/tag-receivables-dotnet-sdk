using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum DivisionMethodType
    {
        [EnumMember(Value = "Fixed")]
        FIXED,
        [EnumMember(Value = "FixedAmount")]
        FIXEDAMOUNT,
        [EnumMember(Value = "Percentage")]
        PERCENTAGE
    }
}
