using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum NotificationEventType
    {
        [EnumMember(Value = "Register")]
        REGISTER,
        [EnumMember(Value = "Update")]
        UPDATE,
        [EnumMember(Value = "Terminate")]
        TERMINATE,
        [EnumMember(Value = "Execute")]
        EXECUTE
    }
}
