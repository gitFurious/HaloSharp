using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class ContentItemTypeB<T> : IEquatable<ContentItemTypeB<T>>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "View")]
        public T View { get; set; }

        public bool Equals(ContentItemTypeB<T> other)
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
                && EqualityComparer<T>.Default.Equals(View, other.View);
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

            if (obj.GetType() != typeof(ContentItemTypeB<T>))
            {
                return false;
            }

            return Equals((ContentItemTypeB<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Type?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ EqualityComparer<T>.Default.GetHashCode(View);
                return hashCode;
            }
        }

        public static bool operator ==(ContentItemTypeB<T> left, ContentItemTypeB<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContentItemTypeB<T> left, ContentItemTypeB<T> right)
        {
            return !Equals(left, right);
        }
    }
}