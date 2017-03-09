using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class CompetitiveSkillRankDesignation : IEquatable<CompetitiveSkillRankDesignation>
    {
        [JsonProperty(PropertyName = "bannerImageUrl")]
        public string BannerImageUrl { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tiers")]
        public List<Tier> Tiers { get; set; }

        public bool Equals(CompetitiveSkillRankDesignation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(BannerImageUrl, other.BannerImageUrl) 
                && ContentId.Equals(other.ContentId)
                && Id == other.Id 
                && string.Equals(Name, other.Name)
                && Tiers.OrderBy(t => t.Id).SequenceEqual(other.Tiers.OrderBy(t => t.Id));
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

            if (obj.GetType() != typeof (CompetitiveSkillRankDesignation))
            {
                return false;
            }

            return Equals((CompetitiveSkillRankDesignation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BannerImageUrl?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Tiers?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CompetitiveSkillRankDesignation left, CompetitiveSkillRankDesignation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CompetitiveSkillRankDesignation left, CompetitiveSkillRankDesignation right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Tier : IEquatable<Tier>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "iconImageUrl")]
        public string IconImageUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public bool Equals(Tier other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ContentId.Equals(other.ContentId) 
                && string.Equals(IconImageUrl, other.IconImageUrl)
                && Id == other.Id;
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

            if (obj.GetType() != typeof (Tier))
            {
                return false;
            }

            return Equals((Tier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (IconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id;
                return hashCode;
            }
        }

        public static bool operator ==(Tier left, Tier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tier left, Tier right)
        {
            return !Equals(left, right);
        }
    }
}