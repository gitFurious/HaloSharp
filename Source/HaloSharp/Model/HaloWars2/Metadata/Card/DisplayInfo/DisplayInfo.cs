using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Card.DisplayInfo
{
    [Serializable]
    public class DisplayInfo : Metadata.DisplayInfo.DisplayInfo, IEquatable<DisplayInfo>
    {
        [JsonProperty(PropertyName = "SubtypeDescription")]
        public string SubtypeDescription { get; set; }

        [JsonProperty(PropertyName = "SpecialAbilityName")]
        public string SpecialAbilityName { get; set; }

        [JsonProperty(PropertyName = "SpecialAbilityDescription")]
        public string SpecialAbilityDescription { get; set; }

        public bool Equals(DisplayInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && string.Equals(SubtypeDescription, other.SubtypeDescription)
                && string.Equals(SpecialAbilityName, other.SpecialAbilityName)
                && string.Equals(SpecialAbilityDescription, other.SpecialAbilityDescription);
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

            if (obj.GetType() != typeof(DisplayInfo))
            {
                return false;
            }

            return Equals((DisplayInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (SubtypeDescription?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SpecialAbilityName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SpecialAbilityDescription?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(DisplayInfo left, DisplayInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DisplayInfo left, DisplayInfo right)
        {
            return !Equals(left, right);
        }
    }
}