using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum TargetType
    {
        [EnumMember(Value = "Contract")]
        CONTRACT,
        [EnumMember(Value = "Consent")]
        CONSENT
    }
}
