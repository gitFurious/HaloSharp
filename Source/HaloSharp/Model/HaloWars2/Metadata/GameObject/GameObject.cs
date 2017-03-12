using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.GameObject
{
    [Serializable]
    public class GameObject : IEquatable<GameObject>
    {
        [JsonProperty(PropertyName = "ObjectTypeId")]
        public string ObjectTypeId { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "Categories")]
        public List<ContentItemTypeD> Categories { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        [JsonProperty(PropertyName = "StandardSupplyCost")]
        public int? StandardSupplyCost { get; set; }

        [JsonProperty(PropertyName = "StandardPopulationCost")]
        public int? StandardPopulationCost { get; set; }

        [JsonProperty(PropertyName = "StandardEnergyCost")]
        public int? StandardEnergyCost { get; set; }

        [JsonProperty(PropertyName = "EffectivenessAgainstInfantry")]
        public string EffectivenessAgainstInfantry { get; set; }

        [JsonProperty(PropertyName = "EffectivenessAgainstVehicles")]
        public string EffectivenessAgainstVehicles { get; set; }

        [JsonProperty(PropertyName = "EffectivenessAgainstAir")]
        public string EffectivenessAgainstAir { get; set; }

        public bool Equals(GameObject other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Categories.OrderBy(c => c.Id).SequenceEqual(other.Categories.OrderBy(c => c.Id))
                && Equals(DisplayInfo, other.DisplayInfo)
                && string.Equals(EffectivenessAgainstAir, other.EffectivenessAgainstAir)
                && string.Equals(EffectivenessAgainstInfantry, other.EffectivenessAgainstInfantry)
                && string.Equals(EffectivenessAgainstVehicles, other.EffectivenessAgainstVehicles)
                && Equals(Image, other.Image)
                && string.Equals(ObjectTypeId, other.ObjectTypeId)
                && StandardEnergyCost == other.StandardEnergyCost
                && StandardPopulationCost == other.StandardPopulationCost
                && StandardSupplyCost == other.StandardSupplyCost;
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

            if (obj.GetType() != typeof(GameObject))
            {
                return false;
            }

            return Equals((GameObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Categories?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (EffectivenessAgainstAir?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (EffectivenessAgainstInfantry?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (EffectivenessAgainstVehicles?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ObjectTypeId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (StandardEnergyCost != null ? StandardEnergyCost.GetHashCode() : 0); ;
                hashCode = (hashCode*397) ^ (StandardPopulationCost != null ? StandardPopulationCost.GetHashCode() : 0); ;
                hashCode = (hashCode*397) ^ (StandardSupplyCost != null ? StandardSupplyCost.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameObject left, GameObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameObject left, GameObject right)
        {
            return !Equals(left, right);
        }
    }
}