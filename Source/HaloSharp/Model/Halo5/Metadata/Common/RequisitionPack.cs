using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata.Common
{
    [Serializable]
    public class RequisitionPack : IEquatable<RequisitionPack>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "creditPrice")]
        public int CreditPrice { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "flair")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.RequisitionPackType? Flair { get; set; }

        [JsonProperty(PropertyName = "giftableAcquisitionMethods")]
        public Enumeration.Halo5.GiftableAcquisitionMethod GiftableAcquisitionMethod { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonProperty(PropertyName = "isGiftOnly")]
        public bool IsGiftOnly { get; set; }

        [JsonProperty(PropertyName = "isNew")]
        public bool IsNew { get; set; }

        [JsonProperty(PropertyName = "isPurchasableFromMarketplace")]
        public bool IsPurchasableFromMarketplace { get; set; }

        [JsonProperty(PropertyName = "isPurchasableWithCredits")]
        public bool IsPurchasableWithCredits { get; set; }

        [JsonProperty(PropertyName = "isStack")]
        public bool IsStack { get; set; }

        [JsonProperty(PropertyName = "stackedRequisitionPacks")]
        public List<RequisitionPack> StackedRequisitionPacks { get; set; }

        [JsonProperty(PropertyName = "largeImageUrl")]
        public string LargeImageUrl { get; set; }

        [JsonProperty(PropertyName = "mediumImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string MediumImageUrl { get; set; }

        [JsonProperty(PropertyName = "merchandisingOrder")]
        public int MerchandisingOrder { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "smallImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallImageUrl { get; set; }

        [JsonProperty(PropertyName = "xboxMarketplaceProductId")]
        public Guid? XboxMarketplaceProductId { get; set; }

        [JsonProperty(PropertyName = "xboxMarketplaceProductUrl")]
        public string XboxMarketplaceProductUrl { get; set; }

        public bool Equals(RequisitionPack other)
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
                && CreditPrice == other.CreditPrice
                && string.Equals(Description, other.Description)
                && Flair == other.Flair
                && GiftableAcquisitionMethod == other.GiftableAcquisitionMethod
                && Id.Equals(other.Id)
                && IsFeatured == other.IsFeatured
                && IsGiftOnly == other.IsGiftOnly
                && IsNew == other.IsNew
                && IsPurchasableFromMarketplace == other.IsPurchasableFromMarketplace
                && IsPurchasableWithCredits == other.IsPurchasableWithCredits
                && IsStack == other.IsStack
                && StackedRequisitionPacks.OrderBy(srp => srp.Id).SequenceEqual(other.StackedRequisitionPacks.OrderBy(srp => srp.Id))
                && string.Equals(LargeImageUrl, other.LargeImageUrl)
                && string.Equals(MediumImageUrl, other.MediumImageUrl)
                && MerchandisingOrder == other.MerchandisingOrder
                && string.Equals(Name, other.Name)
                && string.Equals(SmallImageUrl, other.SmallImageUrl)
                && XboxMarketplaceProductId.Equals(other.XboxMarketplaceProductId)
                && string.Equals(XboxMarketplaceProductUrl, other.XboxMarketplaceProductUrl);
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

            if (obj.GetType() != typeof (RequisitionPack))
            {
                return false;
            }

            return Equals((RequisitionPack) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ CreditPrice;
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Flair.GetHashCode();
                hashCode = (hashCode*397) ^ (int) GiftableAcquisitionMethod;
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ IsFeatured.GetHashCode();
                hashCode = (hashCode*397) ^ IsGiftOnly.GetHashCode();
                hashCode = (hashCode*397) ^ IsNew.GetHashCode();
                hashCode = (hashCode*397) ^ IsPurchasableFromMarketplace.GetHashCode();
                hashCode = (hashCode*397) ^ IsPurchasableWithCredits.GetHashCode();
                hashCode = (hashCode*397) ^ IsStack.GetHashCode();
                hashCode = (hashCode*397) ^ (StackedRequisitionPacks?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (LargeImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MediumImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MerchandisingOrder;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ XboxMarketplaceProductId.GetHashCode();
                hashCode = (hashCode*397) ^ (XboxMarketplaceProductUrl?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(RequisitionPack left, RequisitionPack right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RequisitionPack left, RequisitionPack right)
        {
            return !Equals(left, right);
        }
    }
}