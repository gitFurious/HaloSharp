using System;

namespace HaloSharp.Model.Common
{
    [Serializable]
    public class ISO8601 : IEquatable<ISO8601>
    {
        /// <summary>
        /// //TODO
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public DateTime? ISO8601Date { get; set; }

        public bool Equals(ISO8601 other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ISO8601Date.Equals(other.ISO8601Date);
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

            if (obj.GetType() != typeof(ISO8601))
            {
                return false;
            }

            return Equals((ISO8601)obj);
        }

        public override int GetHashCode()
        {
            return ISO8601Date.GetHashCode();
        }

        public static bool operator ==(ISO8601 left, ISO8601 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ISO8601 left, ISO8601 right)
        {
            return !Equals(left, right);
        }
    }
}
