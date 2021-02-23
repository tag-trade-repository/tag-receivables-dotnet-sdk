using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum ConsentStatus
    {
        [EnumMember(Value = "Active")]
        ACTIVE,
        [EnumMember(Value = "Reject")]
        REJECTED,
        [EnumMember(Value = "Inactive")]
        INACTIVE
    }
}
