using HaloSharp.Model.Stats.CarnageReport.Common;
using HaloSharp.Model.Stats.Common;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.CarnageReport
{
    public class ArenaMatch : BaseMatch
    {
        public List<ArenaMatchPlayerStat> PlayerStats { get; set; }
        public List<TeamStat> TeamStats { get; set; }
    }

    public class ArenaMatchPlayerStat : BasePlayerStat
    {
        public CreditsEarned CreditsEarned { get; set; }
        public CompetitiveSkillRanking CurrentCsr { get; set; }
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }
        public List<OpponentDetails> KilledOpponentDetails { get; set; }
        public int MeasurementMatchesLeft { get; set; }
        public CompetitiveSkillRanking PreviousCsr { get; set; }
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }
        public List<RewardSet> RewardSets { get; set; }
        public XpInfo XpInfo { get; set; }
        
        // TODO: Question sanity.
        //public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
    }
}