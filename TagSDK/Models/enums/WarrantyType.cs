using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum WarrantyType
    {
        [EnumMember(Value = "None")]
        NONE,
        [EnumMember(Value = "Fiduciary")]
        FIDUCIARY,
        [EnumMember(Value = "Pledge")]
        PLEDGE
    }
}
