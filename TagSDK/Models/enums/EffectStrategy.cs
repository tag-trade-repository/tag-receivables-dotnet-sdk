using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum EffectStrategy
    {
        [EnumMember(Value = "Overall")]
        OVERALL,
        [EnumMember(Value = "Specific")]
        SPECIFIC
    }
}
