using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Requisition : IEquatable<Requisition>
    {
        public string CategoryName { get; set; }
        public Guid? CertificationRequisitionId { get; set; }
        public int CreditsAwarded { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public bool IsCertification { get; set; }
        public bool IsMythic { get; set; }
        public bool IsWearable { get; set; }
        public string LargeImageUrl { get; set; }
        public int LevelRequirement { get; set; }
        public string MediumImageUrl { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.RequisitionRarityType RarityType { get; set; }

        public int SellPrice { get; set; }
        public string SmallImageUrl { get; set; }
        public string SubcategoryName { get; set; }
        public int SubcategoryOrder { get; set; }

        [JsonProperty(ItemConverterType = typeof (StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.RequisitionUseType UseType { get; set; }

        // Internal use.
        public string InternalCategoryName { get; set; }
        //public Guid ContentId { get; set; }

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
                && CreditsAwarded == other.CreditsAwarded
                && string.Equals(Description, other.Description)
                && Id.Equals(other.Id)
                && string.Equals(InternalCategoryName, other.InternalCategoryName)
                && IsCertification == other.IsCertification
                && IsMythic == other.IsMythic
                && IsWearable == other.IsWearable
                && string.Equals(LargeImageUrl, other.LargeImageUrl)
                && LevelRequirement == other.LevelRequirement
                && string.Equals(MediumImageUrl, other.MediumImageUrl)
                && string.Equals(Name, other.Name)
                && string.Equals(Rarity, other.Rarity)
                && RarityType == other.RarityType
                && SellPrice == other.SellPrice
                && string.Equals(SmallImageUrl, other.SmallImageUrl)
                && string.Equals(SubcategoryName, other.SubcategoryName)
                && SubcategoryOrder == other.SubcategoryOrder
                && SupportedGameModes.OrderBy(sgm => sgm.ToString()).SequenceEqual(other.SupportedGameModes.OrderBy(sgm => sgm.ToString()))
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
                hashCode = (hashCode*397) ^ CreditsAwarded;
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (InternalCategoryName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsCertification.GetHashCode();
                hashCode = (hashCode*397) ^ IsMythic.GetHashCode();
                hashCode = (hashCode*397) ^ IsWearable.GetHashCode();
                hashCode = (hashCode*397) ^ (LargeImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ LevelRequirement;
                hashCode = (hashCode*397) ^ (MediumImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Rarity?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) RarityType;
                hashCode = (hashCode*397) ^ SellPrice;
                hashCode = (hashCode*397) ^ (SmallImageUrl?.GetHashCode() ?? 0);
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