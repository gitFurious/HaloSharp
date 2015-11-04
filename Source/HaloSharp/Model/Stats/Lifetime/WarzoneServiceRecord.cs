using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Lifetime
{
    public class WarzoneServiceRecord : BaseServiceRecord
    {
        public List<WarzoneServiceRecordResult> Results { get; set; }
    }

    public class WarzoneServiceRecordResult : BaseServiceRecordResult
    {
        public WarzoneResult Result { get; set; }
    }

    public class WarzoneResult : BaseResult
    {
        public WarzoneStat WarzoneStat { get; set; }
    }

    public class WarzoneStat : BaseStat
    {
        public List<ScenarioStat> ScenarioStats { get; set; }
        public int TotalPiesEarned { get; set; }
    }

    public class ScenarioStat : BaseStat
    {
        public FlexibleStats FlexibleStats { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public Guid MapId { get; set; }
        public int TotalPiesEarned { get; set; }
    }
}