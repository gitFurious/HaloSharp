using HaloSharp.Converter;
using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BaseMatch : IEquatable<BaseMatch>
    {
        public Guid GameBaseVariantId { get; set; }
        public Guid GameVariantId { get; set; }
        public bool IsMatchOver { get; set; }
        public bool IsTeamGame { get; set; }
        public Guid MapId { get; set; }
        public Guid MapVariantId { get; set; }
        public Guid PlaylistId { get; set; }
        
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalDuration { get; set; }

        // Internal use only.
        public Guid? SeasonId { get; set; }

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
