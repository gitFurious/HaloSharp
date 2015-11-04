using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Lifetime
{
    public class CustomServiceRecord : BaseServiceRecord
    {
        public List<CustomServiceRecordResult> Results { get; set; }
    }

    public class CustomServiceRecordResult : BaseServiceRecordResult
    {
        public CustomResult Result { get; set; }
    }

    public class CustomResult : BaseResult
    {
        public CustomStats CustomStats { get; set; }
    }

    public class CustomStats : BaseStat
    {
        public List<CustomGameBaseVariantStat> CustomGameBaseVariantStats { get; set; }
        public List<TopGameBaseVariant> TopGameBaseVariants { get; set; }
    }

    public class CustomGameBaseVariantStat : BaseStat
    {
        public FlexibleStats FlexibleStats { get; set; }
        public Guid GameBaseVariantId { get; set; }
    }
}