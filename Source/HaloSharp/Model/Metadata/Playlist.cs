using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Playlist : IEquatable<Playlist>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "gameMode")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.GameMode GameMode { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "isRanked")]
        public bool IsRanked { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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
                   && string.Equals(Name, other.Name)
                   && ContentId.Equals(other.ContentId);
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
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
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