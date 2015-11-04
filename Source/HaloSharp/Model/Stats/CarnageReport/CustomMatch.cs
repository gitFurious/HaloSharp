using HaloSharp.Model.Stats.CarnageReport.Common;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.CarnageReport
{
    public class CustomMatch : BaseMatch
    {
        public List<CustomMatchPlayerStat> PlayerStats { get; set; }
        public List<TeamStat> TeamStats { get; set; }
    }

    public class CustomMatchPlayerStat : BasePlayerStat
    {
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }
        public List<OpponentDetails> KilledOpponentDetails { get; set; }
    }
}