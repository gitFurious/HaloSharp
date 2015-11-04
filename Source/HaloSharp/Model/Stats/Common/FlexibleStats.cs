using HaloSharp.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Common
{
    public class FlexibleStats
    {
        public List<StatCount> ImpulseStatCounts { get; set; }
        public List<StatTimelapse> ImpulseTimelapses { get; set; }
        public List<StatCount> MedalStatCounts { get; set; }
        public List<StatTimelapse> MedalTimelapses { get; set; }
    }

    public class StatTimelapse
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Timelapse { get; set; }
    }

    public class StatCount
    {
        public int Count { get; set; }
        public Guid Id { get; set; }
    }
}