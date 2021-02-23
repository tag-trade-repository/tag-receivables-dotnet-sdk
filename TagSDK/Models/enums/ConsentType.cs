using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum ConsentType
    {
        [EnumMember(Value = "Grant")]
        GRANT,
        [EnumMember(Value = "Update")]
        UPDATE,
        [EnumMember(Value = "Revoke")]
        REVOKE
    }
}
