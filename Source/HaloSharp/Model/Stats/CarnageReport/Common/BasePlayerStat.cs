using System;
using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BasePlayerStat : BaseStat, IEquatable<BasePlayerStat>
    {
        /// <summary>
        /// The player's average lifetime.
        /// </summary>
        [JsonProperty(PropertyName = "AvgLifeTimeOfPlayer")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan AvgLifeTimeOfPlayer { get; set; }

        /// <summary>
        /// Indicates whether the player was present in the match when it ended.
        /// </summary>
        [JsonProperty(PropertyName = "DNF")]
        // ReSharper disable once InconsistentNaming
        public bool DNF { get; set; }

        /// <summary>
        /// The game base variant specific stats for this match. Flexible stats are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "FlexibleStats")]
        public FlexibleStats FlexibleStats { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "PlayerScore")]
        public object PlayerScore { get; set; }

        /// <summary>
        /// Internal use only. This will always be null.
        /// </summary>
        [JsonProperty(PropertyName = "PostMatchRatings")]
        public object PostMatchRatings { get; set; }

        /// <summary>
        /// Internal use only. This will always be null.
        /// </summary>
        [JsonProperty(PropertyName = "PreMatchRatings")]
        public object PreMatchRatings { get; set; }

        /// <summary>
        /// The player's team-agnostic ranking.
        /// </summary>
        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        /// <summary>
        /// The ID of the team that the player was on when the match ended. 
        /// </summary>
        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        public bool Equals(BasePlayerStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && AvgLifeTimeOfPlayer.Equals(other.AvgLifeTimeOfPlayer)
                && DNF == other.DNF
                && Equals(FlexibleStats, other.FlexibleStats)
                && Equals(Player, other.Player)
                && Equals(PlayerScore, other.PlayerScore)
                && Equals(PostMatchRatings, other.PostMatchRatings)
                && Equals(PreMatchRatings, other.PreMatchRatings)
                && Rank == other.Rank
                && TeamId == other.TeamId;
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

            if (obj.GetType() != typeof (BasePlayerStat))
            {
                return false;
            }

            return Equals((BasePlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ AvgLifeTimeOfPlayer.GetHashCode();
                hashCode = (hashCode*397) ^ DNF.GetHashCode();
                hashCode = (hashCode*397) ^ (FlexibleStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Player?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PlayerScore?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PostMatchRatings?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PreMatchRatings?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Rank;
                hashCode = (hashCode*397) ^ TeamId;
                return hashCode;
            }
        }

        public static bool operator ==(BasePlayerStat left, BasePlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BasePlayerStat left, BasePlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}