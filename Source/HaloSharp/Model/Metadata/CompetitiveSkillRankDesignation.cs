using System.Collections.Generic;

namespace HaloSharp.Model.Metadata
{
    public class CompetitiveSkillRankDesignation
    {
        public string BannerImageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tier> Tiers { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }

    public class Tier
    {
        public string IconImageUrl { get; set; }
        public int Id { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}