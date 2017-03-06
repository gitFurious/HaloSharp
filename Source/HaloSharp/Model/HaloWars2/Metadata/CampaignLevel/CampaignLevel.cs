using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Metadata.CampaignLevel
{
    [Serializable]
    public class CampaignLevel : IEquatable<CampaignLevel>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "MaxScore")]
        public int MaxScore { get; set; }

        [JsonProperty(PropertyName = "CriticalObjectives")]
        public List<ContentItemTypeB<CampaignObjective.View>> CriticalObjectives { get; set; }

        [JsonProperty(PropertyName = "BonusObjectives")]
        public List<ContentItemTypeB<CampaignObjective.View>> BonusObjectives { get; set; }

        [JsonProperty(PropertyName = "OptionalObjectives")]
        public List<ContentItemTypeB<CampaignObjective.View>> OptionalObjectives { get; set; }

        [JsonProperty(PropertyName = "Skulls")]
        public List<ContentItemTypeB<Skull.View>> Skulls { get; set; }

        [JsonProperty(PropertyName = "AwardedPacks")]
        public List<ContentItemTypeB<Pack.View>> AwardedPacks { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        public bool Equals(CampaignLevel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id
                && MaxScore == other.MaxScore
                && CriticalObjectives.OrderBy(o => o.Id).SequenceEqual(other.CriticalObjectives.OrderBy(o => o.Id))
                && BonusObjectives.OrderBy(o => o.Id).SequenceEqual(other.BonusObjectives.OrderBy(o => o.Id))
                && OptionalObjectives.OrderBy(o => o.Id).SequenceEqual(other.OptionalObjectives.OrderBy(o => o.Id))
                && Skulls.OrderBy(s => s.Id).SequenceEqual(other.Skulls.OrderBy(s => s.Id))
                && AwardedPacks.OrderBy(s => s.Id).SequenceEqual(other.AwardedPacks.OrderBy(s => s.Id))
                && Equals(DisplayInfo, other.DisplayInfo);
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

            if (obj.GetType() != typeof(CampaignLevel))
            {
                return false;
            }

            return Equals((CampaignLevel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ MaxScore;
                hashCode = (hashCode*397) ^ (CriticalObjectives?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (BonusObjectives?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (OptionalObjectives?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Skulls?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (AwardedPacks?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CampaignLevel left, CampaignLevel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignLevel left, CampaignLevel right)
        {
            return !Equals(left, right);
        }
    }
}
