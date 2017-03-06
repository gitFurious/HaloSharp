using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats
{
    [Serializable]
    public class PlayerSummary : IEquatable<PlayerSummary>
    {
        [JsonProperty(PropertyName = "CustomSummary")]
        public CustomSummary CustomSummary { get; set; }

        [JsonProperty(PropertyName = "MatchmakingSummary")]
        public MatchmakingSummary MatchmakingSummary { get; set; }

        public bool Equals(PlayerSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(CustomSummary, other.CustomSummary)
                && Equals(MatchmakingSummary, other.MatchmakingSummary);
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

            if (obj.GetType() != typeof(PlayerSummary))
            {
                return false;
            }

            return Equals((PlayerSummary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((CustomSummary != null ? CustomSummary.GetHashCode() : 0)*397) ^ (MatchmakingSummary != null ? MatchmakingSummary.GetHashCode() : 0);
            }
        }

        public static bool operator ==(PlayerSummary left, PlayerSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerSummary left, PlayerSummary right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CustomSummary : IEquatable<CustomSummary>
    {
        [JsonProperty(PropertyName = "SkirmishStats")]
        public SkirmishSummary SkirmishSummary { get; set; }

        [JsonProperty(PropertyName = "CustomStats")]
        public Common.Stats CustomStats { get; set; }

        public bool Equals(CustomSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(CustomStats, other.CustomStats)
                   && Equals(SkirmishSummary, other.SkirmishSummary);
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

            if (obj.GetType() != typeof(CustomSummary))
            {
                return false;
            }

            return Equals((CustomSummary)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((CustomStats != null ? CustomStats.GetHashCode() : 0) * 397) ^ (SkirmishSummary != null ? SkirmishSummary.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CustomSummary left, CustomSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomSummary left, CustomSummary right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class MatchmakingSummary : IEquatable<MatchmakingSummary>
    {
        [JsonProperty(PropertyName = "SocialPlaylistStats")]
        public List<Common.Stats> SocialPlaylistStats { get; set; }

        [JsonProperty(PropertyName = "RankedPlaylistStats")]
        public List<Common.Stats> RankedPlaylistStats { get; set; }

        public bool Equals(MatchmakingSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return RankedPlaylistStats.OrderBy(rps => rps.PlaylistId).SequenceEqual(other.RankedPlaylistStats.OrderBy(rps => rps.PlaylistId))
                   && SocialPlaylistStats.OrderBy(rps => rps.PlaylistId).SequenceEqual(other.SocialPlaylistStats.OrderBy(rps => rps.PlaylistId));
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

            if (obj.GetType() != typeof(MatchmakingSummary))
            {
                return false;
            }

            return Equals((MatchmakingSummary)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((RankedPlaylistStats?.GetHashCode() ?? 0) * 397) ^ (SocialPlaylistStats?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(MatchmakingSummary left, MatchmakingSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchmakingSummary left, MatchmakingSummary right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class SkirmishSummary : IEquatable<SkirmishSummary>
    {
        [JsonProperty(PropertyName = "SinglePlayerStats")]
        public Common.Stats SinglePlayerStats { get; set; }

        [JsonProperty(PropertyName = "MultiplayerStats")]
        public Common.Stats MultiplayerStats { get; set; }

        public bool Equals(SkirmishSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(MultiplayerStats, other.MultiplayerStats)
                   && Equals(SinglePlayerStats, other.SinglePlayerStats);
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

            if (obj.GetType() != typeof(SkirmishSummary))
            {
                return false;
            }

            return Equals((SkirmishSummary)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((MultiplayerStats != null ? MultiplayerStats.GetHashCode() : 0) * 397) ^ (SinglePlayerStats != null ? SinglePlayerStats.GetHashCode() : 0);
            }
        }

        public static bool operator ==(SkirmishSummary left, SkirmishSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SkirmishSummary left, SkirmishSummary right)
        {
            return !Equals(left, right);
        }
    }
}
