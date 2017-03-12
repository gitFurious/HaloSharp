using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class Common : IEquatable<Common>
    {
        [JsonProperty(PropertyName = "Owner")]
        public string Owner { get; set; }

        [JsonProperty(PropertyName = "CreatedUtc")]
        public DateTime CreatedUtc { get; set; }

        [JsonProperty(PropertyName = "ModifiedUtc")]
        public DateTime ModifiedUtc { get; set; }

        [JsonProperty(PropertyName = "PublishedUtc")]
        public DateTime PublishedUtc { get; set; }

        [JsonProperty(PropertyName = "Container")]
        public int Container { get; set; }

        public bool Equals(Common other)
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
                && CreatedUtc.Equals(other.CreatedUtc)
                && ModifiedUtc.Equals(other.ModifiedUtc)
                && PublishedUtc.Equals(other.PublishedUtc)
                && Container == other.Container;
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

            if (obj.GetType() != typeof(Common))
            {
                return false;
            }

            return Equals((Common) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Owner?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ CreatedUtc.GetHashCode();
                hashCode = (hashCode*397) ^ ModifiedUtc.GetHashCode();
                hashCode = (hashCode*397) ^ PublishedUtc.GetHashCode();
                hashCode = (hashCode*397) ^ Container;
                return hashCode;
            }
        }

        public static bool operator ==(Common left, Common right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Common left, Common right)
        {
            return !Equals(left, right);
        }
    }
}