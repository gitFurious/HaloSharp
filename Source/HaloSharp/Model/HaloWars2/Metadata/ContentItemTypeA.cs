using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class ContentItemTypeA<T> : IEquatable<ContentItemTypeA<T>>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "View")]
        public T View { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public List<Link> Links { get; set; }
    
        [JsonProperty(PropertyName = "ChildrenCount")]
        public int ChildrenCount { get; set; }

        public bool Equals(ContentItemTypeA<T> other)
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
                && string.Equals(Type, other.Type)
                && EqualityComparer<T>.Default.Equals(View, other.View)
                && Links.OrderBy(l => l.Uri).SequenceEqual(other.Links.OrderBy(l => l.Uri))
                && ChildrenCount == other.ChildrenCount;
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

            if (obj.GetType() != typeof(ContentItemTypeA<T>))
            {
                return false;
            }

            return Equals((ContentItemTypeA<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Type?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ EqualityComparer<T>.Default.GetHashCode(View);
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ChildrenCount;
                return hashCode;
            }
        }

        public static bool operator ==(ContentItemTypeA<T> left, ContentItemTypeA<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContentItemTypeA<T> left, ContentItemTypeA<T> right)
        {
            return !Equals(left, right);
        }
    }
}