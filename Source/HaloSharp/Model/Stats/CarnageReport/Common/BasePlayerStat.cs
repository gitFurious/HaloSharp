using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class BasePlayerStat : BaseStat
    {
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan AvgLifeTimeOfPlayer { get; set; }

        // ReSharper disable once InconsistentNaming
        public bool DNF { get; set; }

        public FlexibleStats FlexibleStats { get; set; }
        public Identity Player { get; set; }
        public int Rank { get; set; }
        public int TeamId { get; set; }

        // Internal use only.
        //public object PreMatchRatings { get; set; } //This will always be null.
        //public object PostMatchRatings { get; set; } //This will always be null.
    }
}