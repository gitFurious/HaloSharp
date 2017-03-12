using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CompetitiveSkillRankDesignationTier
{
    [Serializable]
    public class Tier : IEquatable<Tier>
    {
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

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

            return Id == other.Id
                && Equals(Image, other.Image);
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

            if (obj.GetType() != typeof(Tier))
            {
                return false;
            }

            return Equals((Tier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ (Image != null ? Image.GetHashCode() : 0);
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
