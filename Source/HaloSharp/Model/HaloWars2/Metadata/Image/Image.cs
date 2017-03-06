using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Image
{
    [Serializable]
    public class Image : IEquatable<Image>
    {
        [JsonProperty(PropertyName = "Width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "Height")]
        public int Height { get; set; }

        public bool Equals(Image other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Width == other.Width
                && Height == other.Height;
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

            if (obj.GetType() != typeof(Image))
            {
                return false;
            }

            return Equals((Image) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width*397) ^ Height;
            }
        }

        public static bool operator ==(Image left, Image right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Image left, Image right)
        {
            return !Equals(left, right);
        }
    }
}