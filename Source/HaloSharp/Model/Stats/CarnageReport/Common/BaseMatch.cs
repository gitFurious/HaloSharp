using HaloSharp.Converter;
using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class BaseMatch
    {
        public Guid GameBaseVariantId { get; set; }
        public Guid GameVariantId { get; set; }
        public bool IsMatchOver { get; set; }
        public bool IsTeamGame { get; set; }
        public Guid MapId { get; set; }
        public Guid MapVariantId { get; set; }
        public Guid PlaylistId { get; set; }
        
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalDuration { get; set; }

        // Internal use only.
        public Guid? SeasonId { get; set; }
    }
}
