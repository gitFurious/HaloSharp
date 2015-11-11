using System;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Identity : IEquatable<Identity>
    {
        public string Gamertag { get; set; }

        // Internal use only.
        //public object Xuid { get; set; } //This will always be null.

        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Gamertag, other.Gamertag);
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

            if (obj.GetType() != typeof (Identity))
            {
                return false;
            }

            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return Gamertag?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Identity left, Identity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identity left, Identity right)
        {
            return !Equals(left, right);
        }
    }
}