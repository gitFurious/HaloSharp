using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Impulse : IEquatable<Impulse>
    {
        public uint Id { get; set; }

        // Internal use.
        public string InternalName { get; set; }
        //public string ContentId { get; set; }

        public bool Equals(Impulse other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id
                && string.Equals(InternalName, other.InternalName);
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

            if (obj.GetType() != typeof (Impulse))
            {
                return false;
            }

            return Equals((Impulse) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Id*397) ^ (InternalName?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(Impulse left, Impulse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Impulse left, Impulse right)
        {
            return !Equals(left, right);
        }
    }
}