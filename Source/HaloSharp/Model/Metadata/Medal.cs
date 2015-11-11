using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Medal : IEquatable<Medal>
    {
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.MedalType Classification { get; set; } //TODO: enums don't match documentation.

        public string Description { get; set; }
        public int Difficulty { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }
        public SpriteLocation SpriteLocation { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

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
        public int Height { get; set; }
        public int Left { get; set; }
        public int SpriteHeight { get; set; }
        public string SpriteSheetUri { get; set; }
        public int SpriteWidth { get; set; }
        public int Top { get; set; }
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