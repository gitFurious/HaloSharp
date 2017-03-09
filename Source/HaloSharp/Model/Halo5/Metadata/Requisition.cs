using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Requisition : IEquatable<Requisition>
    {
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty(PropertyName = "certificationRequisitionId")]
        public Guid? CertificationRequisitionId { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "internalCategoryName")]
        public string InternalCategoryName { get; set; }

        [JsonProperty(PropertyName = "internalSubcategoryName")]
        public string InternalSubcategoryName { get; set; }

        [JsonProperty(PropertyName = "isCertification")]
        public bool IsCertification { get; set; }

        [JsonProperty(PropertyName = "isMythic")]
        public bool IsMythic { get; set; }

        [JsonProperty(PropertyName = "isWearable")]
        public bool IsWearable { get; set; }

        [JsonProperty(PropertyName = "hideIfNotAcquired")]
        public bool HideIfNotAcquired { get; set; }

        [JsonProperty(PropertyName = "largeImageUrl")]
        public string LargeImageUrl { get; set; }

        [JsonProperty(PropertyName = "levelRequirement")]
        public int LevelRequirement { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rarity")]
        public string Rarity { get; set; }

        [JsonProperty(PropertyName = "rarityType")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.RequisitionRarityType RarityType { get; set; }

        [JsonProperty(PropertyName = "sellPrice")]
        public int SellPrice { get; set; }

        [JsonProperty(PropertyName = "subcategoryName")]
        public string SubcategoryName { get; set; }

        [JsonProperty(PropertyName = "subcategoryOrder")]
        public int SubcategoryOrder { get; set; }

        [JsonProperty(PropertyName = "supportedGameModes", ItemConverterType = typeof(StringEnumConverter))]
        public List<Enumeration.Halo5.GameMode> SupportedGameModes { get; set; }

        [JsonProperty(PropertyName = "useType")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.RequisitionUseType UseType { get; set; }

        public bool Equals(Requisition other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(CategoryName, other.CategoryName)
                && CertificationRequisitionId.Equals(other.CertificationRequisitionId)
                && ContentId.Equals(other.ContentId)
                && string.Equals(Description, other.Description)
                && Id.Equals(other.Id)
                && string.Equals(InternalCategoryName, other.InternalCategoryName)
                && string.Equals(InternalSubcategoryName, other.InternalSubcategoryName)
                && IsCertification == other.IsCertification
                && IsMythic == other.IsMythic
                && IsWearable == other.IsWearable
                && HideIfNotAcquired == other.HideIfNotAcquired
                && string.Equals(LargeImageUrl, other.LargeImageUrl)
                && LevelRequirement == other.LevelRequirement
                && string.Equals(Name, other.Name)
                && string.Equals(Rarity, other.Rarity)
                && RarityType == other.RarityType
                && SellPrice == other.SellPrice
                && string.Equals(SubcategoryName, other.SubcategoryName)
                && SubcategoryOrder == other.SubcategoryOrder
                && SupportedGameModes.OrderBy(sgm => sgm).SequenceEqual(other.SupportedGameModes.OrderBy(sgm => sgm))
                && UseType == other.UseType;
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

            if (obj.GetType() != typeof (Requisition))
            {
                return false;
            }

            return Equals((Requisition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CategoryName?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ CertificationRequisitionId.GetHashCode();
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (InternalCategoryName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (InternalSubcategoryName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsCertification.GetHashCode();
                hashCode = (hashCode*397) ^ IsMythic.GetHashCode();
                hashCode = (hashCode*397) ^ IsWearable.GetHashCode();
                hashCode = (hashCode*397) ^ HideIfNotAcquired.GetHashCode();
                hashCode = (hashCode*397) ^ (LargeImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ LevelRequirement;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Rarity?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) RarityType;
                hashCode = (hashCode*397) ^ SellPrice;
                hashCode = (hashCode*397) ^ (SubcategoryName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ SubcategoryOrder;
                hashCode = (hashCode*397) ^ (SupportedGameModes?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) UseType;
                return hashCode;
            }
        }

        public static bool operator ==(Requisition left, Requisition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Requisition left, Requisition right)
        {
            return !Equals(left, right);
        }
    }
}