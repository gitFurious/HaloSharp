using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime.Common
{
    [Serializable]
    public class TopGameBaseVariant : IEquatable<TopGameBaseVariant>
    {
        /// <summary>
        /// Id of the game base variant.
        /// </summary>
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        /// <summary>
        /// Rank between 1-3.
        /// </summary>
        [JsonProperty(PropertyName = "GameBaseVariantRank")]
        public int GameBaseVariantRank { get; set; }

        /// <summary>
        /// Number of games played in game base variant.
        /// </summary>
        [JsonProperty(PropertyName = "NumberOfMatchesCompleted")]
        public int NumberOfMatchesCompleted { get; set; }

        /// <summary>
        /// Number of matches won on game base variant.
        /// </summary>
        [JsonProperty(PropertyName = "NumberOfMatchesWon")]
        public int NumberOfMatchesWon { get; set; }

        public bool Equals(TopGameBaseVariant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return GameBaseVariantId.Equals(other.GameBaseVariantId)
                && GameBaseVariantRank == other.GameBaseVariantRank
                && NumberOfMatchesCompleted == other.NumberOfMatchesCompleted
                && NumberOfMatchesWon == other.NumberOfMatchesWon;
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

            if (obj.GetType() != typeof (TopGameBaseVariant))
            {
                return false;
            }

            return Equals((TopGameBaseVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ GameBaseVariantRank;
                hashCode = (hashCode*397) ^ NumberOfMatchesCompleted;
                hashCode = (hashCode*397) ^ NumberOfMatchesWon;
                return hashCode;
            }
        }

        public static bool operator ==(TopGameBaseVariant left, TopGameBaseVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TopGameBaseVariant left, TopGameBaseVariant right)
        {
            return !Equals(left, right);
        }
    }
}