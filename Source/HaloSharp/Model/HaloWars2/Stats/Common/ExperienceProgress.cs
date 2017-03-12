using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class ExperienceProgress : IEquatable<ExperienceProgress>
    {
        [JsonProperty(PropertyName = "PreviousTotalXP")]
        public int PreviousTotalExperience { get; set; }

        [JsonProperty(PropertyName = "GameplayXP")]
        public int GameplayExperience { get; set; }

        [JsonProperty(PropertyName = "ChallengesXP")]
        public int ChallengesExperience { get; set; }

        [JsonProperty(PropertyName = "UpdatedTotalXP")]
        public int UpdatedTotalExperience { get; set; }

        [JsonProperty(PropertyName = "CompletedSpartanRanks")]
        public List<CompletedSpartanRank> CompletedSpartanRanks { get; set; }

        public bool Equals(ExperienceProgress other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ChallengesExperience == other.ChallengesExperience
                && CompletedSpartanRanks.OrderBy(csr => csr.Id).SequenceEqual(other.CompletedSpartanRanks.OrderBy(csr => csr.Id))
                && GameplayExperience == other.GameplayExperience
                && PreviousTotalExperience == other.PreviousTotalExperience
                && UpdatedTotalExperience == other.UpdatedTotalExperience;
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

            if (obj.GetType() != typeof(ExperienceProgress))
            {
                return false;
            }

            return Equals((ExperienceProgress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ChallengesExperience;
                hashCode = (hashCode*397) ^ (CompletedSpartanRanks?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ GameplayExperience;
                hashCode = (hashCode*397) ^ PreviousTotalExperience;
                hashCode = (hashCode*397) ^ UpdatedTotalExperience;
                return hashCode;
            }
        }

        public static bool operator ==(ExperienceProgress left, ExperienceProgress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExperienceProgress left, ExperienceProgress right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CompletedSpartanRank : IEquatable<CompletedSpartanRank>
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "PacksAwarded")]
        public List<Guid> PacksAwarded { get; set; }

        public bool Equals(CompletedSpartanRank other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id)
                && PacksAwarded.OrderBy(pa => pa).SequenceEqual(other.PacksAwarded.OrderBy(pa => pa));
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

            if (obj.GetType() != typeof(CompletedSpartanRank))
            {
                return false;
            }

            return Equals((CompletedSpartanRank)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ (PacksAwarded?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CompletedSpartanRank left, CompletedSpartanRank right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CompletedSpartanRank left, CompletedSpartanRank right)
        {
            return !Equals(left, right);
        }
    }
}