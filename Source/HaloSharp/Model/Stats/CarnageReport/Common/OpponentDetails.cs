using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class OpponentDetails : IEquatable<OpponentDetails>
    {
        public string GamerTag { get; set; }
        public int TotalKills { get; set; }

        public bool Equals(OpponentDetails other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(GamerTag, other.GamerTag)
                && TotalKills == other.TotalKills;
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

            if (obj.GetType() != typeof (OpponentDetails))
            {
                return false;
            }

            return Equals((OpponentDetails) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((GamerTag == null ? GamerTag.GetHashCode() : 0)*397) ^ TotalKills;
            }
        }

        public static bool operator ==(OpponentDetails left, OpponentDetails right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpponentDetails left, OpponentDetails right)
        {
            return !Equals(left, right);
        }
    }
}