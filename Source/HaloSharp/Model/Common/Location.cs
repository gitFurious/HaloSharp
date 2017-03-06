using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Common
{
    [Serializable]
    public class Location : IEquatable<Location>
    {
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }

        [JsonProperty(PropertyName = "z")]
        public double Z { get; set; }

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return X.Equals(other.X)
                   && Y.Equals(other.Y)
                   && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(Location))
            {
                return false;
            }

            return Equals((Location)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Location left, Location right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !Equals(left, right);
        }
    }
}