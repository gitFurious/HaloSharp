using HaloSharp.Converter;
using HaloSharp.Model.Stats.CarnageReport.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.CarnageReport
{
    public class CampaignMatch : BaseMatch
    {
        public Enumeration.Difficulty Difficulty { get; set; }
        public bool MissionCompleted { get; set; }
        public List<CampaignMatchPlayerStat> PlayerStats { get; set; }
        public List<int> Skulls { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalMissionPlaythroughTime { get; set; }
    }

    public class CampaignMatchPlayerStat : BasePlayerStat
    {
        public int BiggestKillScore { get; set; }
        public int Score { get; set; }
    }
}