using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Stats.CarnageReport.Common;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class ArenaMatch : BaseMatch, IEquatable<ArenaMatch>
    {
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<ArenaMatchPlayerStat> PlayerStats { get; set; }

        [JsonProperty(PropertyName = "TeamStats")]
        public List<TeamStat> TeamStats { get; set; }

        public bool Equals(ArenaMatch other)
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

            if (obj.GetType() != typeof(ArenaMatch))
            {
                return false;
            }

            return Equals((ArenaMatch)obj);
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

        public static bool operator ==(ArenaMatch left, ArenaMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaMatch left, ArenaMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaMatchPlayerStat : BasePlayerStat, IEquatable<ArenaMatchPlayerStat>
    {
        [JsonProperty(PropertyName = "CreditsEarned")]
        public CreditsEarned CreditsEarned { get; set; }

        [JsonProperty(PropertyName = "CurrentCsr")]
        public CompetitiveSkillRanking CurrentCsr { get; set; }

        [JsonProperty(PropertyName = "KilledByOpponentDetails")]
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }

        [JsonProperty(PropertyName = "KilledOpponentDetails")]
        public List<OpponentDetails> KilledOpponentDetails { get; set; }

        [JsonProperty(PropertyName = "MeasurementMatchesLeft")]
        public int MeasurementMatchesLeft { get; set; }

        [JsonProperty(PropertyName = "MetaCommendationDeltas")]
        public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }

        [JsonProperty(PropertyName = "PreviousCsr")]
        public CompetitiveSkillRanking PreviousCsr { get; set; }

        [JsonProperty(PropertyName = "ProgressiveCommendationDeltas")]
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }

        [JsonProperty(PropertyName = "RewardSets")]
        public List<RewardSet> RewardSets { get; set; }

        [JsonProperty(PropertyName = "XpInfo")]
        public XpInfo XpInfo { get; set; }

        public bool Equals(ArenaMatchPlayerStat other)
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
                && Equals(CurrentCsr, other.CurrentCsr)
                && KilledByOpponentDetails.OrderBy(kbod => kbod.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(kbod => kbod.GamerTag))
                && KilledOpponentDetails.OrderBy(kod => kod.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(kod => kod.GamerTag))
                && MeasurementMatchesLeft == other.MeasurementMatchesLeft
                && MetaCommendationDeltas.OrderBy(mcd => mcd.Id).SequenceEqual(other.MetaCommendationDeltas.OrderBy(mcd => mcd.Id))
                && Equals(PreviousCsr, other.PreviousCsr)
                && ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id).SequenceEqual(other.ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id))
                && RewardSets.OrderBy(rs => rs.Id).SequenceEqual(other.RewardSets.OrderBy(rs => rs.Id))
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

            if (obj.GetType() != typeof(ArenaMatchPlayerStat))
            {
                return false;
            }

            return Equals((ArenaMatchPlayerStat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CreditsEarned?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (CurrentCsr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledByOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MeasurementMatchesLeft;
                hashCode = (hashCode*397) ^ (MetaCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PreviousCsr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ProgressiveCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RewardSets?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (XpInfo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(ArenaMatchPlayerStat left, ArenaMatchPlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaMatchPlayerStat left, ArenaMatchPlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}