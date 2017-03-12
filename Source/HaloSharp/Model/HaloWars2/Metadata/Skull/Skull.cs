using System;

namespace HaloSharp.Model.HaloWars2.Metadata.Skull
{
    [Serializable]
    public class Skull : IEquatable<Skull>
    {
        public int Id { get; set; }

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

            return Id == other.Id;
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

            if (obj.GetType() != typeof(Skull))
            {
                return false;
            }

            return Equals((Skull) obj);
        }

        public override int GetHashCode()
        {
            return Id;
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