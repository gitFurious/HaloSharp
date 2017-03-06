using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class MatchStart : MatchEvent, IEquatable<MatchStart>
    {
        [JsonProperty(PropertyName = "MatchId")]
        public Guid MatchId { get; set; }

        [JsonProperty(PropertyName = "GameMode")]
        public Enumeration.HaloWars2.GameMode GameMode { get; set; }

        [JsonProperty(PropertyName = "MatchType")]
        public Enumeration.HaloWars2.MatchType MatchType { get; set; }

        [JsonProperty(PropertyName = "MapId")]
        public string MapId { get; set; }

        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid PlaylistId { get; set; }

        [JsonProperty(PropertyName = "TeamSize")]
        public int TeamSize { get; set; }

        [JsonProperty(PropertyName = "IsDefaultRuleSet")]
        public bool IsDefaultRuleSet { get; set; }

        public bool Equals(MatchStart other)
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
                && GameMode == other.GameMode
                && IsDefaultRuleSet == other.IsDefaultRuleSet
                && string.Equals(MapId, other.MapId)
                && MatchId.Equals(other.MatchId)
                && MatchType == other.MatchType
                && PlaylistId.Equals(other.PlaylistId)
                && TeamSize == other.TeamSize;
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

            if (obj.GetType() != typeof(MatchStart))
            {
                return false;
            }

            return Equals((MatchStart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (int) GameMode;
                hashCode = (hashCode*397) ^ IsDefaultRuleSet.GetHashCode();
                hashCode = (hashCode*397) ^ (MapId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MatchId.GetHashCode();
                hashCode = (hashCode*397) ^ (int) MatchType;
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ TeamSize;
                return hashCode;
            }
        }

        public static bool operator ==(MatchStart left, MatchStart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchStart left, MatchStart right)
        {
            return !Equals(left, right);
        }
    }
}