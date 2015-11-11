using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Weapon : IEquatable<Weapon>
    {
        public string Description { get; set; }
        public uint Id { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.WeaponType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Weapon other)
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
                && Id == other.Id
                && IsUsableByPlayer == other.IsUsableByPlayer
                && string.Equals(LargeIconImageUrl, other.LargeIconImageUrl)
                && string.Equals(Name, other.Name)
                && string.Equals(SmallIconImageUrl, other.SmallIconImageUrl)
                && Type == other.Type;
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

            if (obj.GetType() != typeof (Weapon))
            {
                return false;
            }

            return Equals((Weapon) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ IsUsableByPlayer.GetHashCode();
                hashCode = (hashCode*397) ^ (LargeIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public static bool operator ==(Weapon left, Weapon right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Weapon left, Weapon right)
        {
            return !Equals(left, right);
        }
    }
}