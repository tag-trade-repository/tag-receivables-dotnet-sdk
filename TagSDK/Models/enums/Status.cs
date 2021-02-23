using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum Status
    {
        [EnumMember(Value = "Registered")]
        REGISTERED,
        [EnumMember(Value = "Declined")]
        DECLINED,
        [EnumMember(Value = "Updated")]
        UPDATED
    }
}
