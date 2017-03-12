using Newtonsoft.Json;
using System;

namespace HaloSharp.Converter
{
    internal class MillisecondConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (TimeSpan);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<int>(reader);

            try
            {
                return TimeSpan.FromMilliseconds(value);
            }
            catch
            {
                return default(TimeSpan);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timeSpan = (TimeSpan)value;
            serializer.Serialize(writer, (int)timeSpan.TotalMilliseconds);
        }
    }
}