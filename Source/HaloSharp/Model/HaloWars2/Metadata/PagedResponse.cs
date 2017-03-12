using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class PagedResponse<T> : IEquatable<PagedResponse<T>>
    {
        [JsonProperty(PropertyName = "Paging")]
        public Paging Paging { get; set; }

        [JsonProperty(PropertyName = "ContentItems")]
        public List<T> ContentItems { get; set; }

        public bool Equals(PagedResponse<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Paging, other.Paging) 
                && ContentItems.SequenceEqual(other.ContentItems);
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

            if (obj.GetType() != typeof(PagedResponse<T>))
            {
                return false;
            }

            return Equals((PagedResponse<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Paging?.GetHashCode() ?? 0)*397) ^ (ContentItems?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(PagedResponse<T> left, PagedResponse<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PagedResponse<T> left, PagedResponse<T> right)
        {
            return !Equals(left, right);
        }
    }
}