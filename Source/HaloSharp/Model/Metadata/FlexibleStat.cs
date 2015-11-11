using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class FlexibleStat : IEquatable<FlexibleStat>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.FlexibleStatType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(FlexibleStat other)
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
                && string.Equals(Name, other.Name)
                && Type == other.Type;
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

            if (obj.GetType() != typeof (FlexibleStat))
            {
                return false;
            }

            return Equals((FlexibleStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public static bool operator ==(FlexibleStat left, FlexibleStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FlexibleStat left, FlexibleStat right)
        {
            return !Equals(left, right);
        }
    }
}