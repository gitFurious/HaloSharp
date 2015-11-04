using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    public class Playlist
    {
        public string Description { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.GameMode GameMode { get; set; }

        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsRanked { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}