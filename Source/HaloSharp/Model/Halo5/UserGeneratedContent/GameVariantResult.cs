using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.UserGeneratedContent
{
    [Serializable]
    public class GameVariantResult : IEquatable<GameVariantResult>
    {
        [JsonProperty(PropertyName = "Results")]
        public List<GameVariant> Results { get; set; }

        [JsonProperty(PropertyName = "Start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "ResultCount")]
        public int ResultCount { get; set; }

        [JsonProperty(PropertyName = "TotalCount")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(GameVariantResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Results.OrderBy(r => r.Identity.ResourceId).SequenceEqual(other.Results.OrderBy(r => r.Identity.ResourceId))
                && Start == other.Start
                && Count == other.Count
                && ResultCount == other.ResultCount
                && TotalCount == other.TotalCount
                && Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key));
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

            if (obj.GetType() != typeof(GameVariantResult))
            {
                return false;
            }

            return Equals((GameVariantResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Results?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Start;
                hashCode = (hashCode*397) ^ Count;
                hashCode = (hashCode*397) ^ ResultCount;
                hashCode = (hashCode*397) ^ TotalCount;
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameVariantResult left, GameVariantResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameVariantResult left, GameVariantResult right)
        {
            return !Equals(left, right);
        }
    }
}
