using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum EffectType
    {
        [EnumMember(Value = "Warranty")]
        WARRANTY,
        [EnumMember(Value = "OwnershipAssignment")]
        OWNERSHIPASSIGNMENT,
        [EnumMember(Value = "Pawn")]
        PAWN
    }
}
