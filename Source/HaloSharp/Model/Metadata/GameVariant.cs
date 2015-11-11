using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class GameVariant : IEquatable<GameVariant>
    {
        public string Description { get; set; }
        public Guid? GameBaseVariantId { get; set; }
        public string IconUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(GameVariant other)
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
                && GameBaseVariantId.Equals(other.GameBaseVariantId)
                && string.Equals(IconUrl, other.IconUrl)
                && Id.Equals(other.Id)
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

            if (obj.GetType() != typeof (GameVariant))
            {
                return false;
            }

            return Equals((GameVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameVariant left, GameVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameVariant left, GameVariant right)
        {
            return !Equals(left, right);
        }
    }
}