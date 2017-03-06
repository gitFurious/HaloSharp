using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Stats
{
    [Serializable]
    public class SeasonSummary : IEquatable<SeasonSummary>
    {
        [JsonProperty(PropertyName = "SeasonId")]
        public Guid SeasonId { get; set; }

        [JsonProperty(PropertyName = "RankedPlaylistStats")]
        public List<Common.Stats> RankedPlaylistStats { get; set; }

        public bool Equals(SeasonSummary other)
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
                && SeasonId.Equals(other.SeasonId);
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

            if (obj.GetType() != typeof(SeasonSummary))
            {
                return false;
            }

            return Equals((SeasonSummary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((RankedPlaylistStats?.GetHashCode() ?? 0)*397) ^ SeasonId.GetHashCode();
            }
        }

        public static bool operator ==(SeasonSummary left, SeasonSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SeasonSummary left, SeasonSummary right)
        {
            return !Equals(left, right);
        }
    }
}