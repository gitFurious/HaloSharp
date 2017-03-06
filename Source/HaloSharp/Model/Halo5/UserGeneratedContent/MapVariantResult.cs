using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats.Common;

namespace HaloSharp.Model.Halo5.UserGeneratedContent
{
    [Serializable]
    public class MapVariantResult : IEquatable<MapVariantResult>
    {
        public List<MapVariant> Results { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public int TotalCount { get; set; }
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(MapVariantResult other)
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

            if (obj.GetType() != typeof(MapVariantResult))
            {
                return false;
            }

            return Equals((MapVariantResult) obj);
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

        public static bool operator ==(MapVariantResult left, MapVariantResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MapVariantResult left, MapVariantResult right)
        {
            return !Equals(left, right);
        }
    }
}
