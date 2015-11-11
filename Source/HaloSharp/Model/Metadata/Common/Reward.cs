using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Metadata.Common
{
    [Serializable]
    public class Reward : IEquatable<Reward>
    {
        public Guid Id { get; set; }
        public List<RequisitionPack> RequisitionPacks { get; set; }
        public int Xp { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Reward other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id)
                && RequisitionPacks.OrderBy(rp => rp.Id).SequenceEqual(other.RequisitionPacks.OrderBy(rp => rp.Id))
                && Xp == other.Xp;
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

            if (obj.GetType() != typeof (Reward))
            {
                return false;
            }

            return Equals((Reward) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (RequisitionPacks?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Xp;
                return hashCode;
            }
        }

        public static bool operator ==(Reward left, Reward right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Reward left, Reward right)
        {
            return !Equals(left, right);
        }
    }
}