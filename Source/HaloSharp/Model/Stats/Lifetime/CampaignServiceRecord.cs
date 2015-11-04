using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Lifetime
{
    public class CampaignServiceRecord : BaseServiceRecord
    {
        public List<CampaignServiceRecordResult> Results { get; set; }
    }

    public class CampaignServiceRecordResult : BaseServiceRecordResult
    {
        public CampaignResult Result { get; set; }
    }

    public class CampaignResult : BaseResult
    {
        public CampaignStat CampaignStat { get; set; }
    }

    public class CampaignStat : BaseStat
    {
        public List<CampaignMissionStat> CampaignMissionStats { get; set; }
    }

    public class CampaignMissionStat : BaseStat
    {
        public Dictionary<Enumeration.Difficulty, Stats> CoopStats { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public Guid MissionId { get; set; }
        public Dictionary<Enumeration.Difficulty, Stats> SoloStats { get; set; }
    }

    public class Stats
    {
        public bool AllSkullsOn { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan FastestCompletionTime { get; set; }

        public int HighestScore { get; set; }
        public List<int> Skulls { get; set; }
        public int TotalTimesCompleted { get; set; }
    }
}