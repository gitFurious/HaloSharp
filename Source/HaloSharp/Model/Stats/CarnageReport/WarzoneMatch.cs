using HaloSharp.Model.Stats.CarnageReport.Common;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.CarnageReport
{
    public class WarzoneMatch : BaseMatch
    {
        public List<WarzonePlayerStat> PlayerStats { get; set; }
        public List<TeamStat> TeamStats { get; set; }
    }

    public class WarzonePlayerStat : BasePlayerStat
    {
        public CreditsEarned CreditsEarned { get; set; }
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }
        public List<OpponentDetails> KilledOpponentDetails { get; set; }
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }
        public List<RewardSet> RewardSets { get; set; }
        public int TotalPiesEarned { get; set; }
        public int WarzoneLevel { get; set; }
        public XpInfo XpInfo { get; set; }

        // TODO: Question sanity.
        //public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
    }
}