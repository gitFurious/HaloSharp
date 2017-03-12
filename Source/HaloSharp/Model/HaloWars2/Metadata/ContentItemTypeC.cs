using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class ContentItemTypeC : IEquatable<ContentItemTypeC>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Identity")]
        public Guid Identity { get; set; }

        public bool Equals(ContentItemTypeC other)
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
                && Identity.Equals(other.Identity);
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

            if (obj.GetType() != typeof(ContentItemTypeC))
            {
                return false;
            }

            return Equals((ContentItemTypeC) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Type?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Identity.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ContentItemTypeC left, ContentItemTypeC right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContentItemTypeC left, ContentItemTypeC right)
        {
            return !Equals(left, right);
        }
    }
}