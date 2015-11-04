using System.Collections.Generic;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class TeamStat
    {
        public int Rank { get; set; }
        public List<RoundStat> RoundStats { get; set; }
        public uint Score { get; set; }
        public int TeamId { get; set; }
    }

    public class RoundStat
    {
        public int Rank { get; set; }
        public int RoundNumber { get; set; }
        public uint Score { get; set; }
    }
}