using HaloSharp.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Stats
{
    [Serializable]
    public class ExperienceSummaryResultSet : IEquatable<ExperienceSummaryResultSet>
    {
        [JsonProperty(PropertyName = "Results")]
        public List<ExperienceSummaryResult> Results { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(ExperienceSummaryResultSet other)
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

            if (obj.GetType() != typeof(ExperienceSummaryResultSet))
            {
                return false;
            }

            return Equals((ExperienceSummaryResultSet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Links?.GetHashCode() ?? 0)*397) ^ (Results?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(ExperienceSummaryResultSet left, ExperienceSummaryResultSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExperienceSummaryResultSet left, ExperienceSummaryResultSet right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ExperienceSummaryResult : IEquatable<ExperienceSummaryResult>
    {
        [JsonProperty(PropertyName = "Id")]
        public string Gamertag { get; set; }

        [JsonProperty(PropertyName = "ResultCode")]
        public Enumeration.Common.QueryResult ResultCode { get; set; }

        [JsonProperty(PropertyName = "Result")]
        public ExperienceSummary ExperienceSummary { get; set; }

        public bool Equals(ExperienceSummaryResult other)
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
                && Equals(ExperienceSummary, other.ExperienceSummary)
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

            if (obj.GetType() != typeof(ExperienceSummaryResult))
            {
                return false;
            }

            return Equals((ExperienceSummaryResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Gamertag?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (ExperienceSummary != null ? ExperienceSummary.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) ResultCode;
                return hashCode;
            }
        }

        public static bool operator ==(ExperienceSummaryResult left, ExperienceSummaryResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExperienceSummaryResult left, ExperienceSummaryResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ExperienceSummary : IEquatable<ExperienceSummary>
    {
        [JsonProperty(PropertyName = "MultiplayerXp")]
        public int MultiplayerXp { get; set; }

        [JsonProperty(PropertyName = "CampaignXp")]
        public int CampaignXp { get; set; }

        [JsonProperty(PropertyName = "TotalXp")]
        public int TotalXp { get; set; }

        [JsonProperty(PropertyName = "LastUpdatedDateUtc")]
        public ISO8601 LastUpdatedDateUtc { get; set; }

        [JsonProperty(PropertyName = "SpartanRankId")]
        public Guid SpartanRankId { get; set; }

        public bool Equals(ExperienceSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CampaignXp == other.CampaignXp
                && Equals(LastUpdatedDateUtc, other.LastUpdatedDateUtc)
                && MultiplayerXp == other.MultiplayerXp
                && SpartanRankId.Equals(other.SpartanRankId)
                && TotalXp == other.TotalXp;
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

            if (obj.GetType() != typeof(ExperienceSummary))
            {
                return false;
            }

            return Equals((ExperienceSummary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CampaignXp;
                hashCode = (hashCode*397) ^ (LastUpdatedDateUtc != null ? LastUpdatedDateUtc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ MultiplayerXp;
                hashCode = (hashCode*397) ^ SpartanRankId.GetHashCode();
                hashCode = (hashCode*397) ^ TotalXp;
                return hashCode;
            }
        }

        public static bool operator ==(ExperienceSummary left, ExperienceSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExperienceSummary left, ExperienceSummary right)
        {
            return !Equals(left, right);
        }
    }
}
