using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class XpInfo : IEquatable<XpInfo>
    {
        /// <summary>
        /// The amount of XP the player earned if they played a boost card for this match, and the boost card criteria 
        /// was met. This is a fixed amount of XP, not a multiplier.
        /// </summary>
        [JsonProperty(PropertyName = "BoostAmount")]
        public int BoostAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "MatchSpeedWinAmount")]
        public int MatchSpeedWinAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "ObjectivesCompletedAmount")]
        public int ObjectivesCompletedAmount { get; set; }

        /// <summary>
        /// The XP awarded to the player based on how their team ranked when the match concluded.
        /// </summary>
        [JsonProperty(PropertyName = "PerformanceXP")]
        public int PerformanceXp { get; set; }

        /// <summary>
        /// The XP awarded to the player for their team-agnostic rank.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerRankXPAward")]
        public int PlayerRankXpAward { get; set; }

        /// <summary>
        /// The portion of the XP the player earned this match that was based on how much time was spent in-match.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerTimePerformanceXPAward")]
        public int PlayerTimePerformanceXpAward { get; set; }

        /// <summary>
        /// The player's Spartan Rank before the match started.
        /// </summary>
        [JsonProperty(PropertyName = "PrevSpartanRank")]
        public int PrevSpartanRank { get; set; }

        /// <summary>
        /// The player's XP before the match started.
        /// </summary>
        [JsonProperty(PropertyName = "PrevTotalXP")]
        public int PrevTotalXp { get; set; }

        /// <summary>
        /// The player's Spartan Rank after the match ended.
        /// </summary>
        [JsonProperty(PropertyName = "SpartanRank")]
        public int SpartanRank { get; set; }

        /// <summary>
        /// The multiplier on the XP earned this match based on their Spartan Rank when the match ended.
        /// </summary>
        [JsonProperty(PropertyName = "SpartanRankMatchXPScalar")]
        public double SpartanRankMatchXpScalar { get; set; }

        /// <summary>
        /// The player's XP after the match ended.
        /// </summary>
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