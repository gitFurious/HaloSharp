using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Map
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        [JsonProperty(ItemConverterType = typeof (StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}