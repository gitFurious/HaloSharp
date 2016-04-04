using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Variant : IEquatable<Variant>
    {
        /// <summary>
        /// The owner. Usually set to null.
        /// </summary>
        [JsonProperty(PropertyName = "Owner")]
        public string Owner { get; set; }

        /// <summary>
        /// The source of the map variant. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Unknown = 0</description>
        /// </item>
        /// <item>
        /// <description>User Generated = 1</description>
        /// </item>
        /// <item>
        /// <description>User Generated = 2</description>
        /// </item>
        /// <item>
        /// <description>Official = 3</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "OwnerType")]
        public Enumeration.OwnerType OwnerType { get; set; }

        /// <summary>
        /// The ID of the map variant. Map variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "ResourceId")]
        public Guid ResourceId { get; set; }

        /// <summary>
        /// The resource type.
        /// /// <list type="bullet">
        /// <item>
        /// <description>GameVariant = 2</description>
        /// </item>
        /// <item>
        /// <description>MapVariant = 3</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "ResourceType")]
        public Enumeration.ResourceType ResourceType { get; set; }

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