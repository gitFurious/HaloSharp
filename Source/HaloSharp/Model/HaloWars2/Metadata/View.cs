using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata
{
    [Serializable]
    public class View : IEquatable<View>
    {
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "Common")]
        public Common Common { get; set; }

        [JsonProperty(PropertyName = "Identity")]
        public Guid Identity { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        public bool Equals(View other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Status, other.Status)
                && Equals(Common, other.Common)
                && Identity.Equals(other.Identity)
                && string.Equals(Title, other.Title);
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

            if (obj.GetType() != typeof(View))
            {
                return false;
            }

            return Equals((View) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Status?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Common != null ? Common.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Identity.GetHashCode();
                hashCode = (hashCode*397) ^ (Title?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(View left, View right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(View left, View right)
        {
            return !Equals(left, right);
        }
    }
}