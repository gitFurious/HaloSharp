using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Medal : IEquatable<Medal>
    {
        /// <summary>
        /// The type of this medal. It will be one of the following options:
        /// <list type="bullet">
        /// <item>
        /// <description>Breakout</description>
        /// </item>
        /// <item>
        /// <description>CaptureTheFlag</description>
        /// </item>
        /// <item>
        /// <description>KillingSpree</description>
        /// </item>
        /// <item>
        /// <description>Multi-kill</description>
        /// </item>
        /// <item>
        /// <description>Strongholds</description>
        /// </item>
        /// <item>
        /// <description>Style</description>
        /// </item>
        /// <item>
        /// <description>Vehicles</description>
        /// </item>
        /// <item>
        /// <description>Warzone</description>
        /// </item>
        /// <item>
        /// <description>WeaponProficiency</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "classification")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.MedalType Classification { get; set; }

        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// A localized description, suitable for display to users. 
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The anticipated difficulty, relative to all other medals of this classification. The difficulty is ordered 
        /// from easiest to most difficult.
        /// </summary>
        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this map medal.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>
        /// A localized name for the medal, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The location on the sprite sheet for the medal.
        /// </summary>
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
        /// <summary>
        /// The height of the full sprite sheet (in pixels). The dimensions of the full sheet are included so that the 
        /// sheet can be resized.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        /// <summary>
        /// The X coordinate where the top-left corner of the sprite is located.
        /// </summary>
        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }

        /// <summary>
        /// The height of this sprite (in pixels).
        /// </summary>
        [JsonProperty(PropertyName = "spriteHeight")]
        public int SpriteHeight { get; set; }

        /// <summary>
        /// A reference to an image that contains all the sprites.
        /// </summary>
        [JsonProperty(PropertyName = "spriteSheetUri")]
        public string SpriteSheetUri { get; set; }

        /// <summary>
        /// The width of this sprite (in pixels).
        /// </summary>
        [JsonProperty(PropertyName = "spriteWidth")]
        public int SpriteWidth { get; set; }

        /// <summary>
        /// The Y coordinate where the top-left corner of the sprite is located.
        /// </summary>
        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }

        /// <summary>
        /// The width of the full sprite sheet (in pixels). The dimensions of the full sheet are included so that the 
        /// sheet can be resized.
        /// </summary>
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