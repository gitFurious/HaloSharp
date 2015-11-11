using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class XpInfo : IEquatable<XpInfo>
    {
        public int BoostAmount { get; set; }
        public int PerformanceXp { get; set; }
        public int PlayerRankXpAward { get; set; }
        public int PlayerTimePerformanceXpAward { get; set; }
        public int PrevSpartanRank { get; set; }
        public int PrevTotalXp { get; set; }
        public int SpartanRank { get; set; }
        public double SpartanRankMatchXpScalar { get; set; }
        public int TotalXp { get; set; }

        public bool Equals(XpInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return BoostAmount == other.BoostAmount
                && PerformanceXp == other.PerformanceXp
                && PlayerRankXpAward == other.PlayerRankXpAward
                && PlayerTimePerformanceXpAward == other.PlayerTimePerformanceXpAward
                && PrevSpartanRank == other.PrevSpartanRank
                && PrevTotalXp == other.PrevTotalXp
                && SpartanRank == other.SpartanRank
                && SpartanRankMatchXpScalar.Equals(other.SpartanRankMatchXpScalar)
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

            if (obj.GetType() != typeof (XpInfo))
            {
                return false;
            }

            return Equals((XpInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BoostAmount;
                hashCode = (hashCode*397) ^ PerformanceXp;
                hashCode = (hashCode*397) ^ PlayerRankXpAward;
                hashCode = (hashCode*397) ^ PlayerTimePerformanceXpAward;
                hashCode = (hashCode*397) ^ PrevSpartanRank;
                hashCode = (hashCode*397) ^ PrevTotalXp;
                hashCode = (hashCode*397) ^ SpartanRank;
                hashCode = (hashCode*397) ^ SpartanRankMatchXpScalar.GetHashCode();
                hashCode = (hashCode*397) ^ TotalXp;
                return hashCode;
            }
        }

        public static bool operator ==(XpInfo left, XpInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(XpInfo left, XpInfo right)
        {
            return !Equals(left, right);
        }
    }
}