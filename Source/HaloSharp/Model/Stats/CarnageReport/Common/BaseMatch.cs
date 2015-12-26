using System;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BaseMatch : IEquatable<BaseMatch>
    {
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        [JsonProperty(PropertyName = "GameVariantId")]
        public Guid GameVariantId { get; set; }

        [JsonProperty(PropertyName = "IsMatchOver")]
        public bool IsMatchOver { get; set; }

        [JsonProperty(PropertyName = "IsTeamGame")]
        public bool IsTeamGame { get; set; }

        [JsonProperty(PropertyName = "MapId")]
        public Guid MapId { get; set; }

        [JsonProperty(PropertyName = "MapVariantId")]
        public Guid MapVariantId { get; set; }

        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid PlaylistId { get; set; }

        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

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
                && IsMatchOver == other.IsMatchOver
                && IsTeamGame == other.IsTeamGame
                && MapId.Equals(other.MapId)
                && MapVariantId.Equals(other.MapVariantId)
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
                hashCode = (hashCode*397) ^ IsMatchOver.GetHashCode();
                hashCode = (hashCode*397) ^ IsTeamGame.GetHashCode();
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ MapVariantId.GetHashCode();
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