using System;
using System.Xml;
using Newtonsoft.Json;

namespace HaloSharp.Converter
{
    internal class TimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (TimeSpan);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);

            try
            {
                return XmlConvert.ToTimeSpan(value);
            }
            catch
            {
                return default(TimeSpan);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timeSpan = (TimeSpan)value;
            serializer.Serialize(writer, XmlConvert.ToString(timeSpan));
        }
    }
}