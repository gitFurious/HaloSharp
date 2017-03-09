using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Common
{
    [Serializable]
    public class Variant : IEquatable<Variant>
    {
        [JsonProperty(PropertyName = "Owner")]
        public string Owner { get; set; }

        [JsonProperty(PropertyName = "OwnerType")]
        public Enumeration.Halo5.OwnerType OwnerType { get; set; }

        [JsonProperty(PropertyName = "ResourceId")]
        public Guid ResourceId { get; set; }

        [JsonProperty(PropertyName = "ResourceType")]
        public Enumeration.Halo5.ResourceType ResourceType { get; set; }

        public bool Equals(Variant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Owner, other.Owner)
                   && OwnerType == other.OwnerType
                   && ResourceId.Equals(other.ResourceId)
                   && ResourceType == other.ResourceType;
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

            if (obj.GetType() != typeof (Variant))
            {
                return false;
            }

            return Equals((Variant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Owner?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) OwnerType;
                hashCode = (hashCode*397) ^ ResourceId.GetHashCode();
                hashCode = (hashCode*397) ^ (int) ResourceType;
                return hashCode;
            }
        }

        public static bool operator ==(Variant left, Variant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Variant left, Variant right)
        {
            return !Equals(left, right);
        }
    }
}