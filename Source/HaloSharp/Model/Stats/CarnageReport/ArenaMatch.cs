using System;
using HaloSharp.Model.Stats.CarnageReport.Common;
using HaloSharp.Model.Stats.Common;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class ArenaMatch : BaseMatch, IEquatable<ArenaMatch>
    {
        public List<ArenaMatchPlayerStat> PlayerStats { get; set; }
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

            if (obj.GetType() != typeof (ArenaMatch))
            {
                return false;
            }

            return Equals((ArenaMatch) obj);
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
        public CreditsEarned CreditsEarned { get; set; }
        public CompetitiveSkillRanking CurrentCsr { get; set; }
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }
        public List<OpponentDetails> KilledOpponentDetails { get; set; }
        public int MeasurementMatchesLeft { get; set; }
        public CompetitiveSkillRanking PreviousCsr { get; set; }
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }
        public List<RewardSet> RewardSets { get; set; }
        public XpInfo XpInfo { get; set; }
        public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
        
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
                && KilledByOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(od => od.GamerTag))
                && KilledOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(od => od.GamerTag))
                && MeasurementMatchesLeft == other.MeasurementMatchesLeft
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

            if (obj.GetType() != typeof (ArenaMatchPlayerStat))
            {
                return false;
            }

            return Equals((ArenaMatchPlayerStat) obj);
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