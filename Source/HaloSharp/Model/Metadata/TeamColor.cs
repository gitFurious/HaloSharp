using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class TeamColor : IEquatable<TeamColor>
    {
        public string Color { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(TeamColor other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Color, other.Color)
                && string.Equals(Description, other.Description)
                && string.Equals(IconUrl, other.IconUrl)
                && Id == other.Id
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

            if (obj.GetType() != typeof (TeamColor))
            {
                return false;
            }

            return Equals((TeamColor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Color?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(TeamColor left, TeamColor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamColor left, TeamColor right)
        {
            return !Equals(left, right);
        }
    }
}