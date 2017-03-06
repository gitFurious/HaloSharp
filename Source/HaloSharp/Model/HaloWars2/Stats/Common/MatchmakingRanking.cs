using HaloSharp.Model.Common;
using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class MatchmakingRanking : IEquatable<MatchmakingRanking>
    {
        [JsonProperty(PropertyName = "Rating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "Variance")]
        public double Variance { get; set; }

        [JsonProperty(PropertyName = "LastModifiedDate")]
        public ISO8601 LastModifiedDate { get; set; }

        public bool Equals(MatchmakingRanking other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(LastModifiedDate, other.LastModifiedDate)
                && Rating.Equals(other.Rating)
                && Variance.Equals(other.Variance);
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

            if (obj.GetType() != typeof(MatchmakingRanking))
            {
                return false;
            }

            return Equals((MatchmakingRanking) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (LastModifiedDate != null ? LastModifiedDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Rating.GetHashCode();
                hashCode = (hashCode*397) ^ Variance.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(MatchmakingRanking left, MatchmakingRanking right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchmakingRanking left, MatchmakingRanking right)
        {
            return !Equals(left, right);
        }
    }
}