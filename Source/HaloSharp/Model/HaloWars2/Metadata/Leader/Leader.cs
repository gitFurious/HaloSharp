using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Leader
{
    [Serializable]
    public class Leader : IEquatable<Leader>
    {
        [JsonProperty(PropertyName = "Faction")]
        public string Faction { get; set; }

        [JsonProperty(PropertyName = "StartingArmyOptions")]
        public List<ContentItemTypeB<StartingArmy.View>> StartingArmyOptions { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        [JsonProperty(PropertyName = "HW2PromotionOffer")]
        public ContentItemTypeC PromotionOffer { get; set; }

        public bool Equals(Leader other)
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
                && string.Equals(Faction, other.Faction)
                && Id == other.Id
                && Equals(Image, other.Image)
                && string.Equals(Name, other.Name)
                && Equals(PromotionOffer, other.PromotionOffer)
                && StartingArmyOptions.OrderBy(sao => sao.Id).SequenceEqual(other.StartingArmyOptions.OrderBy(sao => sao.Id));
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

            if (obj.GetType() != typeof(Leader))
            {
                return false;
            }

            return Equals((Leader) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Faction?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PromotionOffer != null ? PromotionOffer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (StartingArmyOptions?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Leader left, Leader right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Leader left, Leader right)
        {
            return !Equals(left, right);
        }
    }
}