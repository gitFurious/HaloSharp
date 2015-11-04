namespace HaloSharp.Model.Stats.Common
{
    public class CompetitiveSkillRanking
    {
        public int Csr { get; set; }
        public Enumeration.CompetitiveSkillRankingDesignation DesignationId { get; set; }
        public int PercentToNextTier { get; set; }
        public int? Rank { get; set; }
        public int Tier { get; set; }
    }
}