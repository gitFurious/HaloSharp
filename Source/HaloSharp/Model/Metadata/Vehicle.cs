using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Vehicle : IEquatable<Vehicle>
    {
        public string Description { get; set; }
        public uint Id { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Vehicle other)
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

            if (obj.GetType() != typeof (Vehicle))
            {
                return false;
            }

            return Equals((Vehicle) obj);
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
                return hashCode;
            }
        }

        public static bool operator ==(Vehicle left, Vehicle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Vehicle left, Vehicle right)
        {
            return !Equals(left, right);
        }
    }
}