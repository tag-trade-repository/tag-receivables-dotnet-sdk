using System;
using Newtonsoft.Json;

namespace TagSDK.Utils
{
    public class CustomSerializer : JsonConverter<decimal>
    {
        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return (existingValue / 100) + 0.00m;
        }

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            var result = Convert.ToInt64(value * 100);
            writer.WriteValue(result);
        }
    }

}
