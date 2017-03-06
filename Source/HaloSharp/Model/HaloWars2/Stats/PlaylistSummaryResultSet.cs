using HaloSharp.Model.Common;
using HaloSharp.Model.HaloWars2.Stats.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Stats
{
    [Serializable]
    public class PlaylistSummaryResultSet : IEquatable<PlaylistSummaryResultSet>
    {
        [JsonProperty(PropertyName = "Results")]
        public List<PlaylistSummaryResult> Results { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(PlaylistSummaryResultSet other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && Results.OrderBy(r => r.Gamertag).SequenceEqual(other.Results.OrderBy(r => r.Gamertag));
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

            if (obj.GetType() != typeof(PlaylistSummaryResultSet))
            {
                return false;
            }

            return Equals((PlaylistSummaryResultSet)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Links?.GetHashCode() ?? 0) * 397) ^ (Results?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(PlaylistSummaryResultSet left, PlaylistSummaryResultSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlaylistSummaryResultSet left, PlaylistSummaryResultSet right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class PlaylistSummaryResult : IEquatable<PlaylistSummaryResult>
    {
        [JsonProperty(PropertyName = "Id")]
        public string Gamertag { get; set; }

        [JsonProperty(PropertyName = "ResultCode")]
        public Enumeration.Common.QueryResult ResultCode { get; set; }

        [JsonProperty(PropertyName = "Result")]
        public PlaylistSummary PlaylistSummary { get; set; }

        public bool Equals(PlaylistSummaryResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Gamertag, other.Gamertag)
                   && Equals(PlaylistSummary, other.PlaylistSummary)
                   && ResultCode == other.ResultCode;
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

            if (obj.GetType() != typeof(PlaylistSummaryResult))
            {
                return false;
            }

            return Equals((PlaylistSummaryResult)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Gamertag?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (PlaylistSummary != null ? PlaylistSummary.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)ResultCode;
                return hashCode;
            }
        }

        public static bool operator ==(PlaylistSummaryResult left, PlaylistSummaryResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlaylistSummaryResult left, PlaylistSummaryResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class PlaylistSummary : IEquatable<PlaylistSummary>
    {
        [JsonProperty(PropertyName = "Mmr")]
        public MatchmakingRanking MatchmakingRanking { get; set; }

        [JsonProperty(PropertyName = "Csr")]
        public CompetitiveSkillRanking CompetitiveSkillRanking { get; set; }

        public bool Equals(PlaylistSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(CompetitiveSkillRanking, other.CompetitiveSkillRanking)
                   && Equals(MatchmakingRanking, other.MatchmakingRanking);
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

            if (obj.GetType() != typeof(PlaylistSummary))
            {
                return false;
            }

            return Equals((PlaylistSummary)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((CompetitiveSkillRanking != null ? CompetitiveSkillRanking.GetHashCode() : 0) * 397) ^ (MatchmakingRanking != null ? MatchmakingRanking.GetHashCode() : 0);
            }
        }

        public static bool operator ==(PlaylistSummary left, PlaylistSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlaylistSummary left, PlaylistSummary right)
        {
            return !Equals(left, right);
        }
    }
}