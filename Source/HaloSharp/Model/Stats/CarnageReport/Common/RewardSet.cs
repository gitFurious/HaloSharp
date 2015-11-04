using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class RewardSet
    {
        public Guid? CommendationLevelId { get; set; }
        public Guid? CommendationSource { get; set; }

        [JsonProperty(PropertyName = "RewardSet")]
        public Guid Id { get; set; }

        public Enumeration.RewardSourceType RewardSourceType { get; set; }
        public int? SpartanRankSource { get; set; }
    }
}