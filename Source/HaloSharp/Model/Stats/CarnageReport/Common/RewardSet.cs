using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class RewardSet : IEquatable<RewardSet>
    {
        public Guid? CommendationLevelId { get; set; }
        public Guid? CommendationSource { get; set; }

        [JsonProperty(PropertyName = "RewardSet")]
        public Guid Id { get; set; }

        public Enumeration.RewardSourceType RewardSourceType { get; set; }
        public int? SpartanRankSource { get; set; }

        public bool Equals(RewardSet other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CommendationLevelId.Equals(other.CommendationLevelId)
                && CommendationSource.Equals(other.CommendationSource)
                && Id.Equals(other.Id)
                && RewardSourceType == other.RewardSourceType
                && SpartanRankSource == other.SpartanRankSource;
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

            if (obj.GetType() != typeof (RewardSet))
            {
                return false;
            }

            return Equals((RewardSet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommendationLevelId.GetHashCode();
                hashCode = (hashCode*397) ^ CommendationSource.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (int) RewardSourceType;
                hashCode = (hashCode*397) ^ SpartanRankSource.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(RewardSet left, RewardSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RewardSet left, RewardSet right)
        {
            return !Equals(left, right);
        }
    }
}