using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class ContentItemTypeD : IEquatable<ContentItemTypeD>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Identity")]
        public Guid Identity { get; set; }

        [JsonProperty(PropertyName = "Autoroute")]
        public string Autoroute { get; set; }

        public bool Equals(ContentItemTypeD other)
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
                && string.Equals(Type, other.Type)
                && Identity.Equals(other.Identity)
                && string.Equals(Autoroute, other.Autoroute);
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

            if (obj.GetType() != typeof(ContentItemTypeD))
            {
                return false;
            }

            return Equals((ContentItemTypeD) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Type?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Identity.GetHashCode();
                hashCode = (hashCode*397) ^ (Autoroute?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(ContentItemTypeD left, ContentItemTypeD right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContentItemTypeD left, ContentItemTypeD right)
        {
            return !Equals(left, right);
        }
    }
}