using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class CompetitiveSkillRankDesignation
    {
        public string BannerImageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tier> Tiers { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }

    [Serializable]
    public class Tier
    {
        public string IconImageUrl { get; set; }
        public int Id { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}