using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class Paging : IEquatable<Paging>
    {
        [JsonProperty(PropertyName = "StartAt")]
        public int StartAt { get; set; }

        [JsonProperty(PropertyName = "InlineCount")]
        public int InlineCount { get; set; }

        [JsonProperty(PropertyName = "TotalCount")]
        public int TotalCount { get; set; }

        public bool Equals(Paging other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return StartAt == other.StartAt && InlineCount == other.InlineCount && TotalCount == other.TotalCount;
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

            if (obj.GetType() != typeof(Paging))
            {
                return false;
            }

            return Equals((Paging) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StartAt;
                hashCode = (hashCode*397) ^ InlineCount;
                hashCode = (hashCode*397) ^ TotalCount;
                return hashCode;
            }
        }

        public static bool operator ==(Paging left, Paging right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Paging left, Paging right)
        {
            return !Equals(left, right);
        }
    }
}