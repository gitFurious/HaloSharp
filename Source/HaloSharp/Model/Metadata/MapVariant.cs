using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class MapVariant : IEquatable<MapVariant>
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public Guid? MapId { get; set; }
        public string MapImageUrl { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(MapVariant other)
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
                && Id.Equals(other.Id)
                && MapId.Equals(other.MapId)
                && string.Equals(MapImageUrl, other.MapImageUrl)
                && string.Equals(Name, other.Name);
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

            if (obj.GetType() != typeof (MapVariant))
            {
                return false;
            }

            return Equals((MapVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ (MapImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(MapVariant left, MapVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MapVariant left, MapVariant right)
        {
            return !Equals(left, right);
        }
    }
}