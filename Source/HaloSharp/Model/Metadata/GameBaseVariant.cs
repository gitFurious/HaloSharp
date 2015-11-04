using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class GameBaseVariant
    {
        public string IconUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(ItemConverterType = typeof (StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        // Internal use.
        public string InternalName { get; set; }
        //public Guid ContentId { get; set; }
    }
}