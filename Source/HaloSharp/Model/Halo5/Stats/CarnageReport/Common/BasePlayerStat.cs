using System;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Common
{
    [Serializable]
    public class BasePlayerStat : BaseStat, IEquatable<BasePlayerStat>
    {
        [JsonProperty(PropertyName = "AvgLifeTimeOfPlayer")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan AvgLifeTimeOfPlayer { get; set; }

        // ReSharper disable once InconsistentNaming
        [JsonProperty(PropertyName = "DNF")]
        public bool DNF { get; set; }

        [JsonProperty(PropertyName = "FlexibleStats")]
        public FlexibleStats FlexibleStats { get; set; }

        [JsonProperty(PropertyName = "GameEndStatus")]
        public int GameEndStatus { get; set; }

        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        [JsonProperty(PropertyName = "PlayerScore")]
        public int? PlayerScore { get; set; }

        [JsonProperty(PropertyName = "PostMatchRatings")]
        public object PostMatchRatings { get; set; }

        [JsonProperty(PropertyName = "PreMatchRatings")]
        public object PreMatchRatings { get; set; }

        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

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
                && GameEndStatus == other.GameEndStatus
                && Equals(Player, other.Player)
                && PlayerScore == other.PlayerScore
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
                hashCode = (hashCode*397) ^ GameEndStatus;
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