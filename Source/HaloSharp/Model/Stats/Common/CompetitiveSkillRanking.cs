using System;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class CompetitiveSkillRanking : IEquatable<CompetitiveSkillRanking>
    {
        public int Csr { get; set; }
        public Enumeration.CompetitiveSkillRankingDesignation DesignationId { get; set; }
        public int PercentToNextTier { get; set; }
        public int? Rank { get; set; }
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