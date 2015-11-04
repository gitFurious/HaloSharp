using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class FlexibleStat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.FlexibleStatType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}