using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Requisition : IEquatable<Requisition>
    {
        /// <summary>
        /// A localized name for the category of the requisition, suitable for display to users. The text is title 
        /// cased.
        /// </summary>
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// If this is set, this is the ID of the Certification Requisition that is required to earn this requisition.
        /// </summary>
        [JsonProperty(PropertyName = "certificationRequisitionId")]
        public Guid? CertificationRequisitionId { get; set; }

        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// A localized description, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this requisition.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Internal use. A non-localized name for the category of the requisition.
        /// </summary>
        [JsonProperty(PropertyName = "internalCategoryName")]
        public string InternalCategoryName { get; set; }

        /// <summary>
        /// //TODO:
        /// </summary>
        [JsonProperty(PropertyName = "internalSubcategoryName")]
        public string InternalSubcategoryName { get; set; }

        /// <summary>
        /// Indicates if this item is a Certification. Certifications will always be durable and are required to earn 
        /// certain other requisitions.
        /// </summary>
        [JsonProperty(PropertyName = "isCertification")]
        public bool IsCertification { get; set; }

        /// <summary>
        /// Indicates if this requisition has been flagged as having 'mythic status'.
        /// </summary>
        [JsonProperty(PropertyName = "isMythic")]
        public bool IsMythic { get; set; }

        /// <summary>
        /// Indicates whether the requisition is wearable.
        /// </summary>
        [JsonProperty(PropertyName = "isWearable")]
        public bool IsWearable { get; set; }

        /// <summary>
        /// A reference to a large image for icon use. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "largeImageUrl")]
        public string LargeImageUrl { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users. The text is title cased. 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The localized rarity suitable for display to users. Indicates the scarcity and thus rarity of the 
        /// requisition
        /// </summary>
        [JsonProperty(PropertyName = "rarity")]
        public string Rarity { get; set; }

        /// <summary>
        /// The non-localized rarity. Indicates the scarcity and thus rarity of the requisition. The options are (in 
        /// increasing order of rarity):
        /// <list type="bullet">
        /// <item>
        /// <description>Common</description>
        /// </item>
        /// <item>
        /// <description>Uncommon</description>
        /// </item>
        /// <item>
        /// <description>Rare</description>
        /// </item>
        /// <item>
        /// <description>UltraRare</description>
        /// </item>
        /// <item>
        /// <description>Legendary</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "rarityType")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.RequisitionRarityType RarityType { get; set; }

        /// <summary>
        /// This field indicates how many credits the player will receive if they wish to discard this requisition. 
        /// When SellPrice is zero, the card cannot be sold back for credits.
        /// </summary>
        [JsonProperty(PropertyName = "sellPrice")]
        public int SellPrice { get; set; }

        /// <summary>
        /// A localized name for the sub-category of the requisition, suitable for display to users. The text is title 
        /// cased.
        /// </summary>
        [JsonProperty(PropertyName = "subcategoryName")]
        public string SubcategoryName { get; set; }

        /// <summary>
        /// The order of the subcategory in the category.
        /// </summary>
        [JsonProperty(PropertyName = "subcategoryOrder")]
        public int SubcategoryOrder { get; set; }

        /// <summary>
        /// A list that indicates what game modes this base variant is available within. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Arena</description>
        /// </item>
        /// <item>
        /// <description>Campaign</description>
        /// </item>
        /// <item>
        /// <description>Custom</description>
        /// </item>
        /// <item>
        /// <description>Warzone</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "supportedGameModes", ItemConverterType = typeof(StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        /// <summary>
        /// Indicates how the requisition card may be used. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Consumable</description>
        /// </item>
        /// <item>
        /// <description>Durable</description>
        /// </item>
        /// <item>
        /// <description>Boost</description>
        /// </item>
        /// <item>
        /// <description>CreditGranting</description>
        /// </item>
        /// </list>
        /// <para>Consumable: The requisition can be called in and used while in-game. When players call in a 
        /// consumable requisition it is removed from the players inventory.</para>
        /// <para>Durable: The requisition is not usable in-game.Players can only earn one of each durable requisition 
        /// and it is used to model awards such as armor suits, helmets, emblems or other items such as stickers. 
        /// Durables are never removed from the player inventory.</para>
        /// <para>Boost: The requisition is used prior to a match beginning and will modify how many XP or Credits the 
        /// player will earn at the end of the match. When put into effect, it is removed from the player 
        /// inventory.</para>
        /// <para>Credit Granting: When obtained, the requisition will grant the player some amount of credits. Once 
        /// the credits are granted the requisition is immediately removed from the player inventory.</para>
        /// </summary>
        [JsonProperty(PropertyName = "useType")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.RequisitionUseType UseType { get; set; }

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
                && IsCertification == other.IsCertification
                && IsMythic == other.IsMythic
                && IsWearable == other.IsWearable
                && string.Equals(LargeImageUrl, other.LargeImageUrl)
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
                hashCode = (hashCode*397) ^ IsCertification.GetHashCode();
                hashCode = (hashCode*397) ^ IsMythic.GetHashCode();
                hashCode = (hashCode*397) ^ IsWearable.GetHashCode();
                hashCode = (hashCode*397) ^ (LargeImageUrl?.GetHashCode() ?? 0);
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