using HaloSharp.Model.Metadata.Common;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class SpartanRank : IEquatable<SpartanRank>
    {
        public int Id { get; set; }
        public Reward Reward { get; set; }
        public int StartXp { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(SpartanRank other)
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
                && Equals(Reward, other.Reward)
                && StartXp == other.StartXp;
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

            if (obj.GetType() != typeof (SpartanRank))
            {
                return false;
            }

            return Equals((SpartanRank) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Reward?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ StartXp;
                return hashCode;
            }
        }

        public static bool operator ==(SpartanRank left, SpartanRank right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpartanRank left, SpartanRank right)
        {
            return !Equals(left, right);
        }
    }
}