using System;
using Newtonsoft.Json;

namespace HaloSharp.Converter
{
    internal class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Guid) || objectType == typeof (Guid?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);

            Guid guid;
            if (Guid.TryParse(value, out guid))
            {
                return guid;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var guid = (Guid) value;
            serializer.Serialize(writer, guid);
        }
    }
}