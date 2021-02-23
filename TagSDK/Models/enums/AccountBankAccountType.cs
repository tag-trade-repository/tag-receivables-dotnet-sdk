using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum BankAccountType
    {
        [EnumMember(Value = "CC")]
        CC,
        [EnumMember(Value = "CD")]
        CD,
        [EnumMember(Value = "CG")]
        CG,
        [EnumMember(Value = "CI")]
        CI,
        [EnumMember(Value = "PG")]
        PG,
        [EnumMember(Value = "PP")]
        PP
    }
}
