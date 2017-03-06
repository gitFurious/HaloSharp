using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Common
{
    [Serializable]
    public class CompetitiveSkillRanking : IEquatable<CompetitiveSkillRanking>
    {
        /// <summary>
        /// The CSR value. Zero for normal designations.
        /// </summary>
        [JsonProperty(PropertyName = "Csr")]
        public int Csr { get; set; }

        /// <summary>
        /// The Designation of the CSR. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Bronze = 1</description>
        /// </item>
        /// <item>
        /// <description>Silver = 2</description>
        /// </item>
        /// <item>
        /// <description>Gold = 3</description>
        /// </item>
        /// <item>
        /// <description>Platinum = 4</description>
        /// </item>
        /// <item>
        /// <description>Diamond = 5</description>
        /// </item>
        /// <item>
        /// <description>Onyx = 6</description>
        /// </item>
        /// <item>
        /// <description>Champion = 7</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "DesignationId")]
        public Enumeration.Halo5.CompetitiveSkillRankingDesignation DesignationId { get; set; }

        /// <summary>
        /// The percentage of progress towards the next CSR tier.
        /// </summary>
        [JsonProperty(PropertyName = "PercentToNextTier")]
        public int PercentToNextTier { get; set; }

        /// <summary>
        /// If the CSR is Semi-pro or Pro, the player's leaderboard ranking.
        /// </summary>
        [JsonProperty(PropertyName = "Rank")]
        public int? Rank { get; set; }

        /// <summary>
        /// The CSR tier.
        /// </summary>
        [JsonProperty(PropertyName = "Tier")]
        public int Tier { get; set; }

        public bool Equals(CompetitiveSkillRanking other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Csr == other.Csr
                && DesignationId == other.DesignationId
                && PercentToNextTier == other.PercentToNextTier
                && Rank == other.Rank
                && Tier == other.Tier;
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

            if (obj.GetType() != typeof (CompetitiveSkillRanking))
            {
                return false;
            }

            return Equals((CompetitiveSkillRanking) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Csr;
                hashCode = (hashCode*397) ^ (int) DesignationId;
                hashCode = (hashCode*397) ^ PercentToNextTier;
                hashCode = (hashCode*397) ^ Rank.GetHashCode();
                hashCode = (hashCode*397) ^ Tier;
                return hashCode;
            }
        }

        public static bool operator ==(CompetitiveSkillRanking left, CompetitiveSkillRanking right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CompetitiveSkillRanking left, CompetitiveSkillRanking right)
        {
            return !Equals(left, right);
        }
    }
}