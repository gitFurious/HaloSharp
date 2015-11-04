using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Metadata
{
    public class Requisition
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
    }
}