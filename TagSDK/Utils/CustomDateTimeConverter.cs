using Newtonsoft.Json.Converters;

namespace TagSDK.Utils
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }
}
