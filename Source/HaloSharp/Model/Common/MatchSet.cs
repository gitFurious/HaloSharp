using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Common
{
    [Serializable]
    public class MatchSet<T> : IEquatable<MatchSet<T>>
    {
        [JsonProperty(PropertyName = "Start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "ResultCount")]
        public int ResultCount { get; set; }

        [JsonProperty(PropertyName = "Results")]
        public List<T> Results { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(MatchSet<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Count == other.Count
                && Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && ResultCount == other.ResultCount
                && Results.SequenceEqual(other.Results)
                && Start == other.Start;
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

            if (obj.GetType() != typeof(MatchSet<T>))
            {
                return false;
            }

            return Equals((MatchSet<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Count;
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ResultCount;
                hashCode = (hashCode*397) ^ (Results?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Start;
                return hashCode;
            }
        }

        public static bool operator ==(MatchSet<T> left, MatchSet<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchSet<T> left, MatchSet<T> right)
        {
            return !Equals(left, right);
        }
    }
}