using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Image
{
    [Serializable]
    public class View : Metadata.View, IEquatable<View>
    {
        [JsonProperty(PropertyName = "Media")]
        public Media Media { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public Image Image { get; set; }

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

            return base.Equals(other)
                && Equals(Media, other.Media)
                && Equals(Image, other.Image);
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
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (Media?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Image?.GetHashCode() ?? 0);
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