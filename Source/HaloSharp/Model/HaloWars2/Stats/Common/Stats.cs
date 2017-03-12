using HaloSharp.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class Stats : IEquatable<Stats>
    {
        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid? PlaylistId { get; set; }

        [JsonProperty(PropertyName = "PlaylistClassification")]
        public Enumeration.HaloWars2.PlaylistClassification? PlaylistClassification { get; set; }

        [JsonProperty(PropertyName = "HighestCsr")]
        public CompetitiveSkillRanking HighestCsr { get; set; }

        [JsonProperty(PropertyName = "TotalTimePlayed")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? TotalTimePlayed { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesStarted")]
        public int TotalMatchesStarted { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesCompleted")]
        public int TotalMatchesCompleted { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesWon")]
        public int TotalMatchesWon { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesLost")]
        public int TotalMatchesLost { get; set; }

        [JsonProperty(PropertyName = "TotalPointCaptures")]
        public int TotalPointCaptures { get; set; }

        [JsonProperty(PropertyName = "TotalUnitsBuilt")]
        public int TotalUnitsBuilt { get; set; }

        [JsonProperty(PropertyName = "TotalUnitsLost")]
        public int TotalUnitsLost { get; set; }

        [JsonProperty(PropertyName = "TotalUnitsDestroyed")]
        public int TotalUnitsDestroyed { get; set; }

        [JsonProperty(PropertyName = "TotalCardPlays")]
        public int TotalCardPlays { get; set; }

        [JsonProperty(PropertyName = "HighestWaveCompleted")]
        public int HighestWaveCompleted { get; set; }

        [JsonProperty(PropertyName = "LeaderStats")]
        public Dictionary<string, LeaderStats> LeaderStats { get; set; }

        public bool Equals(Stats other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(HighestCsr, other.HighestCsr)
                   && HighestWaveCompleted == other.HighestWaveCompleted
                   && LeaderStats.OrderBy(ls => ls.Key).SequenceEqual(other.LeaderStats.OrderBy(ls => ls.Key))
                   && PlaylistClassification == other.PlaylistClassification
                   && PlaylistId.Equals(other.PlaylistId)
                   && TotalCardPlays == other.TotalCardPlays
                   && TotalMatchesCompleted == other.TotalMatchesCompleted
                   && TotalMatchesLost == other.TotalMatchesLost
                   && TotalMatchesStarted == other.TotalMatchesStarted
                   && TotalMatchesWon == other.TotalMatchesWon
                   && TotalPointCaptures == other.TotalPointCaptures
                   && TotalTimePlayed.Equals(other.TotalTimePlayed)
                   && TotalUnitsBuilt == other.TotalUnitsBuilt
                   && TotalUnitsDestroyed == other.TotalUnitsDestroyed
                   && TotalUnitsLost == other.TotalUnitsLost;
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

            if (obj.GetType() != typeof(Stats))
            {
                return false;
            }

            return Equals((Stats) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = HighestCsr?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ HighestWaveCompleted;
                hashCode = (hashCode*397) ^ (LeaderStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ PlaylistClassification.GetHashCode();
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ TotalCardPlays;
                hashCode = (hashCode*397) ^ TotalMatchesCompleted;
                hashCode = (hashCode*397) ^ TotalMatchesLost;
                hashCode = (hashCode*397) ^ TotalMatchesStarted;
                hashCode = (hashCode*397) ^ TotalMatchesWon;
                hashCode = (hashCode*397) ^ TotalPointCaptures;
                hashCode = (hashCode*397) ^ TotalTimePlayed.GetHashCode();
                hashCode = (hashCode*397) ^ TotalUnitsBuilt;
                hashCode = (hashCode*397) ^ TotalUnitsDestroyed;
                hashCode = (hashCode*397) ^ TotalUnitsLost;
                return hashCode;
            }
        }

        public static bool operator ==(Stats left, Stats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stats left, Stats right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class LeaderStats : IEquatable<LeaderStats>
    {
        [JsonProperty(PropertyName = "TotalTimePlayed")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalTimePlayed { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesStarted")]
        public int TotalMatchesStarted { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesCompleted")]
        public int TotalMatchesCompleted { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesWon")]
        public int TotalMatchesWon { get; set; }

        [JsonProperty(PropertyName = "TotalMatchesLost")]
        public int TotalMatchesLost { get; set; }

        [JsonProperty(PropertyName = "TotalLeaderPowersCast")]
        public int TotalLeaderPowersCast { get; set; }

        public bool Equals(LeaderStats other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return TotalLeaderPowersCast == other.TotalLeaderPowersCast
                   && TotalMatchesCompleted == other.TotalMatchesCompleted
                   && TotalMatchesLost == other.TotalMatchesLost
                   && TotalMatchesStarted == other.TotalMatchesStarted
                   && TotalMatchesWon == other.TotalMatchesWon
                   && TotalTimePlayed.Equals(other.TotalTimePlayed);
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

            if (obj.GetType() != typeof(LeaderStats))
            {
                return false;
            }

            return Equals((LeaderStats)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TotalLeaderPowersCast;
                hashCode = (hashCode * 397) ^ TotalMatchesCompleted;
                hashCode = (hashCode * 397) ^ TotalMatchesLost;
                hashCode = (hashCode * 397) ^ TotalMatchesStarted;
                hashCode = (hashCode * 397) ^ TotalMatchesWon;
                hashCode = (hashCode * 397) ^ TotalTimePlayed.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LeaderStats left, LeaderStats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeaderStats left, LeaderStats right)
        {
            return !Equals(left, right);
        }
    }
}