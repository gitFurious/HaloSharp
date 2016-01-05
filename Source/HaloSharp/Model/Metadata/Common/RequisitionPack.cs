using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata.Common
{
    [Serializable]
    public class RequisitionPack : IEquatable<RequisitionPack>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// If the pack is purchasable via credits, this value contains the number of credits a player must spend to 
        /// acquire one pack.This value is zero when isPurchasableWithCredits is false.
        /// </summary>
        [JsonProperty(PropertyName = "creditPrice")]
        public int CreditPrice { get; set; }

        /// <summary>
        /// A localized description, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Internal use. Indicates the visual treatment of the pack. This is one of the following options:
        /// <list type="bullet">
        /// <item>
        /// <description>None</description>
        /// </item>
        /// <item>
        /// <description>New</description>
        /// </item>
        /// <item>
        /// <description>Hot</description>
        /// </item>
        /// <item>
        /// <description>LeavingSoon</description>
        /// </item>
        /// <item>
        /// <description>MaximumValue</description>
        /// </item>
        /// <item>
        /// <description>Limitedtime</description>
        /// </item>
        /// <item>
        /// <description>Featured</description>
        /// </item>
        /// <item>
        /// <description>BestSeller</description>
        /// </item>
        /// <item>
        /// <description>Popular</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "flair")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.RequisitionPackType? Flair { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this pack.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Internal use. Whether the item should be featured ahead of others.
        /// </summary>
        [JsonProperty(PropertyName = "isFeatured")]
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Internal use. Whether the item should be labeled as "new!"
        /// </summary>
        [JsonProperty(PropertyName = "isNew")]
        public bool IsNew { get; set; }

        /// <summary>
        /// If the pack might be obtainable through the Xbox Live Marketplace, then this value is true.
        /// </summary>
        [JsonProperty(PropertyName = "isPurchasableFromMarketplace")]
        public bool IsPurchasableFromMarketplace { get; set; }

        /// <summary>
        /// If the pack is currently available for purchase by spending credits, then this value is true.
        /// </summary>
        [JsonProperty(PropertyName = "isPurchasableWithCredits")]
        public bool IsPurchasableWithCredits { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "isStack")]
        public bool IsStack { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "stackedRequisitionPacks")]
        public List<RequisitionPack> StackedRequisitionPacks { get; set; }

        /// <summary>
        /// A large image for the pack.
        /// </summary>
        [JsonProperty(PropertyName = "largeImageUrl")]
        public string LargeImageUrl { get; set; }

        /// <summary>
        /// A medium image for the pack.
        /// </summary>
        [JsonProperty(PropertyName = "mediumImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string MediumImageUrl { get; set; }

        /// <summary>
        /// Internal use. The order in which packs are shown for merchandising purposes.
        /// </summary>
        [JsonProperty(PropertyName = "merchandisingOrder")]
        public int MerchandisingOrder { get; set; }

        /// <summary>
        /// A localized name for the pack, suitable for display to users. The text is title cased. 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A small image for the pack.
        /// </summary>
        [JsonProperty(PropertyName = "smallImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallImageUrl { get; set; }

        /// <summary>
        /// If this pack might be obtainable through the Xbox Live Marketplace, this is the product ID. Note: Pricing 
        /// and availability within the Xbox Live marketplace is controlled independently of this value.The presence of 
        /// an Id in this field is not a guarantee the product is purchasable. There may be geographic restrictions 
        /// restricting purchase in certain regions, or the item may not be currently purchasable at all.
        /// </summary>
        [JsonProperty(PropertyName = "xboxMarketplaceProductId")]
        public Guid? XboxMarketplaceProductId { get; set; }

        /// <summary>
        /// If this pack might be obtainable through the Xbox Live Marketplace, this is the URL to the product.
        /// </summary>
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
                && Id.Equals(other.Id)
                && IsFeatured == other.IsFeatured
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
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ IsFeatured.GetHashCode();
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