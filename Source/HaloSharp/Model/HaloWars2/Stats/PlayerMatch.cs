using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using HaloSharp.Model.HaloWars2.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats
{
    [Serializable]
    public class PlayerMatch : IEquatable<PlayerMatch>
    {
        [JsonProperty(PropertyName = "MatchId")]
        public Guid MatchId { get; set; }

        [JsonProperty(PropertyName = "MatchType")]
        public Enumeration.HaloWars2.MatchType MatchType { get; set; }

        [JsonProperty(PropertyName = "GameMode")]
        public Enumeration.HaloWars2.GameMode GameMode { get; set; }

        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid? PlaylistId { get; set; }

        [JsonProperty(PropertyName = "Teams")]
        public Dictionary<string, Common.Team> Teams { get; set; }

        [JsonProperty(PropertyName = "MapId")]
        public string MapId { get; set; }

        [JsonProperty(PropertyName = "MatchStartDate")]
        public ISO8601 MatchStartDate { get; set; }

        [JsonProperty(PropertyName = "PlayerMatchDuration")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan PlayerMatchDuration { get; set; }

        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "TeamPlayerIndex")]
        public int TeamPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "LeaderId")]
        public int LeaderId { get; set; }

        [JsonProperty(PropertyName = "PlayerCompletedMatch")]
        public bool PlayerCompletedMatch { get; set; }

        [JsonProperty(PropertyName = "PlayerMatchOutcome")]
        public Enumeration.HaloWars2.MatchOutcome PlayerMatchOutcome { get; set; }

        [JsonProperty(PropertyName = "XPProgress")]
        public ExperienceProgress ExperienceProgress { get; set; }

        [JsonProperty(PropertyName = "RatingProgress")]
        public RatingProgress RatingProgress { get; set; }

        public bool Equals(PlayerMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(ExperienceProgress, other.ExperienceProgress)
                && GameMode == other.GameMode
                && LeaderId == other.LeaderId
                && string.Equals(MapId, other.MapId)
                && MatchId.Equals(other.MatchId)
                && Equals(MatchStartDate, other.MatchStartDate)
                && MatchType == other.MatchType
                && PlayerCompletedMatch == other.PlayerCompletedMatch
                && PlayerIndex == other.PlayerIndex
                && PlayerMatchDuration.Equals(other.PlayerMatchDuration)
                && PlayerMatchOutcome == other.PlayerMatchOutcome
                && PlaylistId.Equals(other.PlaylistId)
                && Equals(RatingProgress, other.RatingProgress)
                && SeasonId.Equals(other.SeasonId)
                && TeamId == other.TeamId
                && TeamPlayerIndex == other.TeamPlayerIndex
                && Teams.OrderBy(t => t.Key).SequenceEqual(other.Teams.OrderBy(t => t.Key));
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

            if (obj.GetType() != typeof(PlayerMatch))
            {
                return false;
            }

            return Equals((PlayerMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ExperienceProgress != null ? ExperienceProgress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) GameMode;
                hashCode = (hashCode*397) ^ LeaderId;
                hashCode = (hashCode*397) ^ (MapId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MatchId.GetHashCode();
                hashCode = (hashCode*397) ^ (MatchStartDate != null ? MatchStartDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) MatchType;
                hashCode = (hashCode*397) ^ PlayerCompletedMatch.GetHashCode();
                hashCode = (hashCode*397) ^ PlayerIndex;
                hashCode = (hashCode*397) ^ PlayerMatchDuration.GetHashCode();
                hashCode = (hashCode*397) ^ (int) PlayerMatchOutcome;
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ (RatingProgress != null ? RatingProgress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ SeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ TeamId;
                hashCode = (hashCode*397) ^ TeamPlayerIndex;
                hashCode = (hashCode*397) ^ (Teams?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(PlayerMatch left, PlayerMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerMatch left, PlayerMatch right)
        {
            return !Equals(left, right);
        }
    }
}
