using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Tech
{
    [Serializable]
    public class Tech : IEquatable<Tech>
    {
        [JsonProperty(PropertyName = "ObjectTypeId")]
        public string ObjectTypeId { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        public bool Equals(Tech other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(DisplayInfo, other.DisplayInfo)
                && Equals(Image, other.Image)
                && string.Equals(ObjectTypeId, other.ObjectTypeId);
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

            if (obj.GetType() != typeof(Tech))
            {
                return false;
            }

            return Equals((Tech) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ObjectTypeId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Tech left, Tech right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tech left, Tech right)
        {
            return !Equals(left, right);
        }
    }
}