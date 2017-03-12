using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Card
{
    [Serializable]
    public class Card : IEquatable<Card>
    {
        [JsonProperty(PropertyName = "Rarity")]
        public int Rarity { get; set; }

        [JsonProperty(PropertyName = "Entitlement")]
        public ContentItemTypeC Entitlement { get; set; }

        [JsonProperty(PropertyName = "EntitlementRequired")]
        public bool EntitlementRequired { get; set; }

        [JsonProperty(PropertyName = "ExcludeFromCardGeneration")]
        public bool ExcludeFromCardGeneration { get; set; }

        [JsonProperty(PropertyName = "Faction")]
        public string Faction { get; set; }

        [JsonProperty(PropertyName = "Leader")]
        public ContentItemTypeC Leader { get; set; }

        [JsonProperty(PropertyName = "ForegroundImage")]
        public ContentItemTypeB<Image.View> ForegroundImage { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "GameObject")]
        public ContentItemTypeD GameObject { get; set; }

        [JsonProperty(PropertyName = "LastStandNumber")]
        public int? LastStandNumber { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        [JsonProperty(PropertyName = "PlayType")]
        public string PlayType { get; set; }

        [JsonProperty(PropertyName = "Keywords")]
        public List<ContentItemTypeD> Keywords { get; set; }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Rarity == other.Rarity
                && Equals(Entitlement, other.Entitlement)
                && EntitlementRequired == other.EntitlementRequired
                && ExcludeFromCardGeneration == other.ExcludeFromCardGeneration
                && string.Equals(Faction, other.Faction)
                && Equals(Leader, other.Leader)
                && Equals(ForegroundImage, other.ForegroundImage)
                && Equals(DisplayInfo, other.DisplayInfo)
                && Equals(GameObject, other.GameObject)
                && LastStandNumber == other.LastStandNumber
                && EnergyCost == other.EnergyCost
                && string.Equals(PlayType, other.PlayType)
                && Keywords.OrderBy(k => k.Id).SequenceEqual(other.Keywords.OrderBy(k => k.Id));
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

            if (obj.GetType() != typeof(Card))
            {
                return false;
            }

            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Rarity;
                hashCode = (hashCode*397) ^ (Entitlement != null ? Entitlement.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ EntitlementRequired.GetHashCode();
                hashCode = (hashCode*397) ^ ExcludeFromCardGeneration.GetHashCode();
                hashCode = (hashCode*397) ^ (Faction?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Leader != null ? Leader.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ForegroundImage != null ? ForegroundImage.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (GameObject != null ? GameObject.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LastStandNumber.GetHashCode();
                hashCode = (hashCode*397) ^ EnergyCost;
                hashCode = (hashCode*397) ^ (PlayType?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Keywords?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Card left, Card right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !Equals(left, right);
        }
    }
}