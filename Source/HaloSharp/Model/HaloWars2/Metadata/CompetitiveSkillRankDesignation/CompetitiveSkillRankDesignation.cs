using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CompetitiveSkillRankDesignation
{
    [Serializable]
    public class CompetitiveSkillRankDesignation : IEquatable<CompetitiveSkillRankDesignation>
    {
        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        [JsonProperty(PropertyName = "Tiers")]
        public List<ContentItemTypeB<CompetitiveSkillRankDesignationTier.View>> Tiers { get; set; }

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

            return Equals(DisplayInfo, other.DisplayInfo)
                && Id == other.Id
                && Equals(Image, other.Image)
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

            if (obj.GetType() != typeof(CompetitiveSkillRankDesignation))
            {
                return false;
            }

            return Equals((CompetitiveSkillRankDesignation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
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
}