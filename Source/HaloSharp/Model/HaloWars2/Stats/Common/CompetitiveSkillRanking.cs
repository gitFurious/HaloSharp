using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class CompetitiveSkillRanking : IEquatable<CompetitiveSkillRanking>
    {
        [JsonProperty(PropertyName = "Tier")]
        public int? Tier { get; set; }

        [JsonProperty(PropertyName = "Designation")]
        public int? Designation { get; set; }

        [JsonProperty(PropertyName = "Raw")]
        public int? Raw { get; set; }

        [JsonProperty(PropertyName = "PercentToNextTier")]
        public int? PercentToNextTier { get; set; }

        [JsonProperty(PropertyName = "MeasurementMatchesRemaining")]
        public int MeasurementMatchesRemaining { get; set; }

        [JsonProperty(PropertyName = "Rank")]
        public int? Rank { get; set; }

        public bool Equals(CompetitiveSkillRanking other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Designation == other.Designation
                && MeasurementMatchesRemaining == other.MeasurementMatchesRemaining
                && PercentToNextTier == other.PercentToNextTier
                && Rank == other.Rank
                && Raw == other.Raw
                && Tier == other.Tier;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(CompetitiveSkillRanking))
            {
                return false;
            }

            return Equals((CompetitiveSkillRanking) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Designation.GetHashCode();
                hashCode = (hashCode*397) ^ MeasurementMatchesRemaining;
                hashCode = (hashCode*397) ^ PercentToNextTier.GetHashCode();
                hashCode = (hashCode*397) ^ Rank.GetHashCode();
                hashCode = (hashCode*397) ^ Raw.GetHashCode();
                hashCode = (hashCode*397) ^ Tier.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CompetitiveSkillRanking left, CompetitiveSkillRanking right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CompetitiveSkillRanking left, CompetitiveSkillRanking right)
        {
            return !Equals(left, right);
        }
    }
}