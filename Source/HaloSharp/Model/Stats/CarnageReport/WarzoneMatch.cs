using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Stats.CarnageReport.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class WarzoneMatch : BaseMatch, IEquatable<WarzoneMatch>
    {
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<WarzonePlayerStat> PlayerStats { get; set; }

        [JsonProperty(PropertyName = "TeamStats")]
        public List<TeamStat> TeamStats { get; set; }

        public bool Equals(WarzoneMatch other)
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
                && PlayerStats.OrderBy(ps => ps.Player.Gamertag).SequenceEqual(other.PlayerStats.OrderBy(ps => ps.Player.Gamertag))
                && TeamStats.OrderBy(ts => ts.TeamId).SequenceEqual(other.TeamStats.OrderBy(ts => ts.TeamId));
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

            if (obj.GetType() != typeof (WarzoneMatch))
            {
                return false;
            }

            return Equals((WarzoneMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (PlayerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TeamStats?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(WarzoneMatch left, WarzoneMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneMatch left, WarzoneMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WarzonePlayerStat : BasePlayerStat, IEquatable<WarzonePlayerStat>
    {
        [JsonProperty(PropertyName = "CreditsEarned")]
        public CreditsEarned CreditsEarned { get; set; }

        [JsonProperty(PropertyName = "KilledByOpponentDetails")]
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }

        [JsonProperty(PropertyName = "KilledOpponentDetails")]
        public List<OpponentDetails> KilledOpponentDetails { get; set; }

        [JsonProperty(PropertyName = "MetaCommendationDeltas")]
        public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }

        [JsonProperty(PropertyName = "ProgressiveCommendationDeltas")]
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }

        [JsonProperty(PropertyName = "RewardSets")]
        public List<RewardSet> RewardSets { get; set; }

        [JsonProperty(PropertyName = "TotalPiesEarned")]
        public int TotalPiesEarned { get; set; }

        [JsonProperty(PropertyName = "WarzoneLevel")]
        public int WarzoneLevel { get; set; }

        [JsonProperty(PropertyName = "XpInfo")]
        public XpInfo XpInfo { get; set; }

        public bool Equals(WarzonePlayerStat other)
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
                && Equals(CreditsEarned, other.CreditsEarned)
                && KilledByOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(od => od.GamerTag))
                && KilledOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(od => od.GamerTag))
                && MetaCommendationDeltas.OrderBy(mcd => mcd.Id).SequenceEqual(other.MetaCommendationDeltas.OrderBy(mcd => mcd.Id))
                && ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id).SequenceEqual(other.ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id))
                && RewardSets.OrderBy(rs => rs.Id).SequenceEqual(other.RewardSets.OrderBy(rs => rs.Id))
                && TotalPiesEarned == other.TotalPiesEarned
                && WarzoneLevel == other.WarzoneLevel
                && Equals(XpInfo, other.XpInfo);
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

            if (obj.GetType() != typeof (WarzonePlayerStat))
            {
                return false;
            }

            return Equals((WarzonePlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CreditsEarned?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledByOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MetaCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ProgressiveCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RewardSets?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalPiesEarned;
                hashCode = (hashCode*397) ^ WarzoneLevel;
                hashCode = (hashCode*397) ^ (XpInfo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(WarzonePlayerStat left, WarzonePlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzonePlayerStat left, WarzonePlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}