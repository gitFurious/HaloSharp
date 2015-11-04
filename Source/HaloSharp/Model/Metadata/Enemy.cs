using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    public class Enemy
    {
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.Faction Faction { get; set; }

        public uint Id { get; set; }
        public string LageIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}