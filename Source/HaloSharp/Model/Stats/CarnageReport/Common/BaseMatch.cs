using System;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BaseMatch : IEquatable<BaseMatch>
    {
        /// <summary>
        /// The ID of the game base variant for this match. Game base variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        /// <summary>
        /// The variant of the game for this match. Game variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "GameVariantId")]
        public Guid GameVariantId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "GameVariantResourceId")]
        public Stats.Common.Variant GameVariantResourceId { get; set; }

        /// <summary>
        /// Indicates if the match is completed or not. Some match details are available while the match is 
        /// in-progress, but the behavior for incomplete matches in undefined.
        /// </summary>
        [JsonProperty(PropertyName = "IsMatchOver")]
        public bool IsMatchOver { get; set; }

        /// <summary>
        /// Whether this was a team-based game or not.
        /// </summary>
        [JsonProperty(PropertyName = "IsTeamGame")]
        public bool IsTeamGame { get; set; }

        /// <summary>
        /// The ID of the base map for this match. Maps are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "MapId")]
        public Guid MapId { get; set; }

        /// <summary>
        /// The variant of the map for this match. Map variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "MapVariantId")]
        public Guid MapVariantId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "MapVariantResourceId")]
        public Stats.Common.Variant MapVariantResourceId { get; set; }

        /// <summary>
        /// The playlist ID of the match. Playlists are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid PlaylistId { get; set; }

        /// <summary>
        /// ID for the season the match was played in if it was played in a seasonal playlist and null otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

        /// <summary>
        /// The length of the match.
        /// </summary>
        [JsonProperty(PropertyName = "TotalDuration")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan TotalDuration { get; set; }

        public bool Equals(BaseMatch other)
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
                && GameVariantId.Equals(other.GameVariantId)
                && Equals(GameVariantResourceId, other.GameVariantResourceId)
                && IsMatchOver == other.IsMatchOver
                && IsTeamGame == other.IsTeamGame
                && MapId.Equals(other.MapId)
                && MapVariantId.Equals(other.MapVariantId)
                && Equals(MapVariantResourceId, other.MapVariantResourceId)
                && PlaylistId.Equals(other.PlaylistId)
                && SeasonId.Equals(other.SeasonId)
                && TotalDuration.Equals(other.TotalDuration);
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

            if (obj.GetType() != typeof (BaseMatch))
            {
                return false;
            }

            return Equals((BaseMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ GameVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ (GameVariantResourceId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsMatchOver.GetHashCode();
                hashCode = (hashCode*397) ^ IsTeamGame.GetHashCode();
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ MapVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ (MapVariantResourceId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ SeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ TotalDuration.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(BaseMatch left, BaseMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseMatch left, BaseMatch right)
        {
            return !Equals(left, right);
        }
    }
}