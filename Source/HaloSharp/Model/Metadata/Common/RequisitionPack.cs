using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata.Common
{
    [Serializable]
    public class RequisitionPack : IEquatable<RequisitionPack>
    {
        public int CreditPrice { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.RequisitionPackType? Flair { get; set; }

        public Guid Id { get; set; }
        public bool IsPurchasableFromMarketplace { get; set; }
        public bool IsPurchasableWithCredits { get; set; }
        public string LargeImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallImageUrl { get; set; }
        public Guid? XboxMarketplaceProductId { get; set; }
        public string XboxMarketplaceProductUrl { get; set; }

        // Internal use.
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public int MerchandisingOrder { get; set; }
        //public Guid ContentId { get; set; }

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

            return CreditPrice == other.CreditPrice
                && string.Equals(Description, other.Description)
                && Flair == other.Flair
                && Id.Equals(other.Id)
                && IsFeatured == other.IsFeatured
                && IsNew == other.IsNew
                && IsPurchasableFromMarketplace == other.IsPurchasableFromMarketplace
                && IsPurchasableWithCredits == other.IsPurchasableWithCredits
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
                var hashCode = CreditPrice;
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Flair.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ IsFeatured.GetHashCode();
                hashCode = (hashCode*397) ^ IsNew.GetHashCode();
                hashCode = (hashCode*397) ^ IsPurchasableFromMarketplace.GetHashCode();
                hashCode = (hashCode*397) ^ IsPurchasableWithCredits.GetHashCode();
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