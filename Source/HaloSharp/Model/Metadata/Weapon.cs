using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Weapon
    {
        public string Description { get; set; }
        public uint Id { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.WeaponType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}