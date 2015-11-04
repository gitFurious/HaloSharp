using System;

namespace HaloSharp.Model.Stats.Lifetime.Common
{
    public class TopGameBaseVariant
    {
        public Guid GameBaseVariantId { get; set; }
        public int GameBaseVariantRank { get; set; }
        public int NumberOfMatchesCompleted { get; set; }
        public int NumberOfMatchesWon { get; set; }
    }
}