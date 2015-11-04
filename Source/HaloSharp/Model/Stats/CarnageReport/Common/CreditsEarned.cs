namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class CreditsEarned
    {
        public int BoostAmount { get; set; }
        public int PlayerRankAmount { get; set; }
        public Enumeration.CreditsEarnedResultType Result { get; set; }
        public double SpartanRankModifier { get; set; }
        public double TimePlayedAmount { get; set; }
        public int TotalCreditsEarned { get; set; }
    }
}