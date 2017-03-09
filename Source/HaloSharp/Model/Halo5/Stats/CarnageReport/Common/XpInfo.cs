using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Common
{
    [Serializable]
    public class XpInfo : IEquatable<XpInfo>
    {
        [JsonProperty(PropertyName = "BoostAmount")]
        public int BoostAmount { get; set; }

        [JsonProperty(PropertyName = "MatchSpeedWinAmount")]
        public int MatchSpeedWinAmount { get; set; }

        [JsonProperty(PropertyName = "ObjectivesCompletedAmount")]
        public int ObjectivesCompletedAmount { get; set; }

        [JsonProperty(PropertyName = "PerformanceXP")]
        public int? PerformanceXp { get; set; }

        [JsonProperty(PropertyName = "PlayerRankXPAward")]
        public int PlayerRankXpAward { get; set; }

        [JsonProperty(PropertyName = "PlayerTimePerformanceXPAward")]
        public int PlayerTimePerformanceXpAward { get; set; }

        [JsonProperty(PropertyName = "PrevSpartanRank")]
        public int PrevSpartanRank { get; set; }

        [JsonProperty(PropertyName = "PrevTotalXP")]
        public int PrevTotalXp { get; set; }

        [JsonProperty(PropertyName = "SpartanRank")]
        public int SpartanRank { get; set; }

        [JsonProperty(PropertyName = "SpartanRankMatchXPScalar")]
        public double SpartanRankMatchXpScalar { get; set; }

        [JsonProperty(PropertyName = "TotalXP")]
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
                && MatchSpeedWinAmount == other.MatchSpeedWinAmount
                && ObjectivesCompletedAmount == other.ObjectivesCompletedAmount
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
                hashCode = (hashCode*397) ^ MatchSpeedWinAmount;
                hashCode = (hashCode*397) ^ ObjectivesCompletedAmount;
                hashCode = (hashCode*397) ^ PerformanceXp.GetHashCode();
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