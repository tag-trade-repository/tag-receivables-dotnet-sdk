using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace TagSDK.Utils
{
    internal static class EnumUtils
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field,
                             typeof(EnumMemberAttribute)) is EnumMemberAttribute attr)
                    {
                        return attr.Value;
                    }
                }
            }
            return null;
        }
    }
}
