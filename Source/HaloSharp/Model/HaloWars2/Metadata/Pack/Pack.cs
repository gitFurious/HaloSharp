using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Metadata.Pack
{
    [Serializable]
    public class Pack : IEquatable<Pack>
    {
        [JsonProperty(PropertyName = "HW2PackRules")]
        public List<ContentItemTypeC> PackRules { get; set; }

        [JsonProperty(PropertyName = "FrontImageHD")]
        public ContentItemTypeB<Image.View> FrontImage { get; set; }

        [JsonProperty(PropertyName = "BackImageHD")]
        public ContentItemTypeB<Image.View> BackImage { get; set; }

        [JsonProperty(PropertyName = "BackImage4K")]
        public ContentItemTypeB<Image.View> BackImage4K { get; set; }

        [JsonProperty(PropertyName = "HighlightImageHD")]
        public ContentItemTypeB<Image.View> HighlightImage { get; set; }

        [JsonProperty(PropertyName = "HighlightImage4K")]
        public ContentItemTypeB<Image.View> HighlightImage4K { get; set; }

        [JsonProperty(PropertyName = "FrontImage4K")]
        public ContentItemTypeB<Image.View> FrontImage4K { get; set; }

        [JsonProperty(PropertyName = "StackGroup")]
        public string StackGroup { get; set; }

        [JsonProperty(PropertyName = "InventorySortPriority")]
        public int InventorySortPriority { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<Displayinfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "MarketplaceProductId")]
        public string MarketplaceProductId { get; set; }

        [JsonProperty(PropertyName = "UWPProductId")]
        public string ProductId { get; set; }

        public bool Equals(Pack other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PackRules.OrderBy(pr => pr.Identity).SequenceEqual(other.PackRules.OrderBy(pr => pr.Identity))
                && Equals(FrontImage, other.FrontImage)
                && Equals(BackImage, other.BackImage)
                && Equals(BackImage4K, other.BackImage4K)
                && Equals(HighlightImage, other.HighlightImage)
                && Equals(HighlightImage4K, other.HighlightImage4K)
                && Equals(FrontImage4K, other.FrontImage4K)
                && string.Equals(StackGroup, other.StackGroup)
                && InventorySortPriority == other.InventorySortPriority
                && Equals(DisplayInfo, other.DisplayInfo)
                && string.Equals(MarketplaceProductId, other.MarketplaceProductId)
                && string.Equals(ProductId, other.ProductId);
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

            if (obj.GetType() != typeof(Pack))
            {
                return false;
            }

            return Equals((Pack) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = PackRules?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (FrontImage != null ? FrontImage.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BackImage != null ? BackImage.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BackImage4K != null ? BackImage4K.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (HighlightImage != null ? HighlightImage.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (HighlightImage4K != null ? HighlightImage4K.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FrontImage4K != null ? FrontImage4K.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (StackGroup?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ InventorySortPriority;
                hashCode = (hashCode*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (MarketplaceProductId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ProductId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Pack left, Pack right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pack left, Pack right)
        {
            return !Equals(left, right);
        }
    }
}