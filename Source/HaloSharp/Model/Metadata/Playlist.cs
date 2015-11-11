using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Playlist : IEquatable<Playlist>
    {
        public string Description { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.GameMode GameMode { get; set; }

        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsRanked { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

        public bool Equals(Playlist other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Description, other.Description)
                && GameMode == other.GameMode
                && Id.Equals(other.Id)
                && string.Equals(ImageUrl, other.ImageUrl)
                && IsActive == other.IsActive
                && IsRanked == other.IsRanked
                && string.Equals(Name, other.Name);
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

            if (obj.GetType() != typeof (Playlist))
            {
                return false;
            }

            return Equals((Playlist) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) GameMode;
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (ImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsActive.GetHashCode();
                hashCode = (hashCode*397) ^ IsRanked.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Playlist left, Playlist right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Playlist left, Playlist right)
        {
            return !Equals(left, right);
        }
    }
}