using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Medal : IEquatable<Medal>
    {
        [JsonProperty(PropertyName = "classification")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.MedalType Classification { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "spriteLocation")]
        public SpriteLocation SpriteLocation { get; set; }

        public bool Equals(Medal other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Classification == other.Classification
                && ContentId.Equals(other.ContentId)
                && string.Equals(Description, other.Description)
                && Difficulty == other.Difficulty
                && Id == other.Id
                && string.Equals(Name, other.Name)
                && Equals(SpriteLocation, other.SpriteLocation);
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

            if (obj.GetType() != typeof (Medal))
            {
                return false;
            }

            return Equals((Medal) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Classification;
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Difficulty;
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SpriteLocation?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Medal left, Medal right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Medal left, Medal right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class SpriteLocation : IEquatable<SpriteLocation>
    {
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }

        [JsonProperty(PropertyName = "spriteHeight")]
        public int SpriteHeight { get; set; }

        [JsonProperty(PropertyName = "spriteSheetUri")]
        public string SpriteSheetUri { get; set; }

        [JsonProperty(PropertyName = "spriteWidth")]
        public int SpriteWidth { get; set; }

        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        public bool Equals(SpriteLocation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Height == other.Height
                && Left == other.Left
                && SpriteHeight == other.SpriteHeight
                && string.Equals(SpriteSheetUri, other.SpriteSheetUri)
                && SpriteWidth == other.SpriteWidth
                && Top == other.Top
                && Width == other.Width;
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

            if (obj.GetType() != typeof (SpriteLocation))
            {
                return false;
            }

            return Equals((SpriteLocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Height;
                hashCode = (hashCode*397) ^ Left;
                hashCode = (hashCode*397) ^ SpriteHeight;
                hashCode = (hashCode*397) ^ (SpriteSheetUri?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ SpriteWidth;
                hashCode = (hashCode*397) ^ Top;
                hashCode = (hashCode*397) ^ Width;
                return hashCode;
            }
        }

        public static bool operator ==(SpriteLocation left, SpriteLocation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpriteLocation left, SpriteLocation right)
        {
            return !Equals(left, right);
        }
    }
}