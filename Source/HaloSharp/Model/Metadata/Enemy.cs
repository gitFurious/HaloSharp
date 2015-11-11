using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Enemy : IEquatable<Enemy>
    {
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.Faction Faction { get; set; }

        public uint Id { get; set; }
        public string LageIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Enemy other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Description, other.Description)
                && Faction == other.Faction
                && Id == other.Id
                && string.Equals(LageIconImageUrl, other.LageIconImageUrl)
                && string.Equals(Name, other.Name)
                && string.Equals(SmallIconImageUrl, other.SmallIconImageUrl);
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

            if (obj.GetType() != typeof (Enemy))
            {
                return false;
            }

            return Equals((Enemy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) Faction;
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ (LageIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallIconImageUrl?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Enemy left, Enemy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enemy left, Enemy right)
        {
            return !Equals(left, right);
        }
    }
}