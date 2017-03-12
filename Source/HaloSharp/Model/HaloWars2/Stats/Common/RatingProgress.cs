using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class RatingProgress : IEquatable<RatingProgress>
    {
        [JsonProperty(PropertyName = "PreviousCsr")]
        public CompetitiveSkillRanking PreviousCompetitiveSkillRanking { get; set; }

        [JsonProperty(PropertyName = "UpdatedCsr")]
        public CompetitiveSkillRanking UpdatedCompetitiveSkillRanking { get; set; }

        [JsonProperty(PropertyName = "PreviousMmr")]
        public MatchmakingRanking PreviousMatchmakingRanking { get; set; }

        [JsonProperty(PropertyName = "UpdatedMmr")]
        public MatchmakingRanking UpdatedMatchmakingRanking { get; set; }

        public bool Equals(RatingProgress other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(PreviousCompetitiveSkillRanking, other.PreviousCompetitiveSkillRanking)
                && Equals(PreviousMatchmakingRanking, other.PreviousMatchmakingRanking)
                && Equals(UpdatedCompetitiveSkillRanking, other.UpdatedCompetitiveSkillRanking)
                && Equals(UpdatedMatchmakingRanking, other.UpdatedMatchmakingRanking);
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

            if (obj.GetType() != typeof(RatingProgress))
            {
                return false;
            }

            return Equals((RatingProgress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (PreviousCompetitiveSkillRanking != null ? PreviousCompetitiveSkillRanking.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PreviousMatchmakingRanking != null ? PreviousMatchmakingRanking.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (UpdatedCompetitiveSkillRanking != null ? UpdatedCompetitiveSkillRanking.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (UpdatedMatchmakingRanking != null ? UpdatedMatchmakingRanking.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(RatingProgress left, RatingProgress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RatingProgress left, RatingProgress right)
        {
            return !Equals(left, right);
        }
    }
}