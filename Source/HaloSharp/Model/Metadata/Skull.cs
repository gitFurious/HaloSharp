using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Skull : IEquatable<Skull>
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public Guid? MissionId { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Skull other)
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
                && MissionId.Equals(other.MissionId)
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

            if (obj.GetType() != typeof (Skull))
            {
                return false;
            }

            return Equals((Skull) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ MissionId.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Skull left, Skull right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Skull left, Skull right)
        {
            return !Equals(left, right);
        }
    }
}