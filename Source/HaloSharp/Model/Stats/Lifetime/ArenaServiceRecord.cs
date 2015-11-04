using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Lifetime
{
    public class ArenaServiceRecord : BaseServiceRecord
    {
        public List<ArenaServiceRecordResult> Results { get; set; }
    }

    public class ArenaServiceRecordResult : BaseServiceRecordResult
    {
        public ArenaResult Result { get; set; }
    }

    public class ArenaResult : BaseResult
    {
        public ArenaStat ArenaStats { get; set; }
    }

    public class ArenaStat : BaseStat
    {
        public List<ArenaGameBaseVariantStat> ArenaGameBaseVariantStats { get; set; }
        public List<ArenaPlaylistStat> ArenaPlaylistStats { get; set; }
        public CompetitiveSkillRanking HighestCsrAttained { get; set; }
        public Guid? HighestCsrPlaylistId { get; set; }
        public List<TopGameBaseVariant> TopGameBaseVariants { get; set; }
    }

    public class ArenaGameBaseVariantStat : BaseStat
    {
        public FlexibleStats FlexibleStats { get; set; }
        public Guid GameBaseVariantId { get; set; }
    }

    public class ArenaPlaylistStat : BaseStat
    {
        public CompetitiveSkillRanking Csr { get; set; }
        public CompetitiveSkillRanking HighestCsr { get; set; }
        public int MeasurementMatchesLeft { get; set; }
        public Guid PlaylistId { get; set; }
    }
}