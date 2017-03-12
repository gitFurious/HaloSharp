using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class Link : IEquatable<Link>
    {
        [JsonProperty(PropertyName = "Absolute")]
        public bool Absolute { get; set; }

        [JsonProperty(PropertyName = "Relation")]
        public string Relation { get; set; }

        [JsonProperty(PropertyName = "URI")]
        public string Uri { get; set; }

        public bool Equals(Link other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Absolute == other.Absolute
                && string.Equals(Relation, other.Relation)
                && string.Equals(Uri, other.Uri);
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

            if (obj.GetType() != typeof(Link))
            {
                return false;
            }

            return Equals((Link) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Absolute.GetHashCode();
                hashCode = (hashCode*397) ^ (Relation?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Uri?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Link left, Link right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Link left, Link right)
        {
            return !Equals(left, right);
        }
    }
}