using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata.Common
{
    public class RequisitionPack
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
    }
}