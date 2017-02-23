using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Playlist : IEquatable<Playlist>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// A localized description for the playlist, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// A list that indicates what game modes this base variant is available within. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Arena</description>
        /// </item>
        /// <item>
        /// <description>Campaign</description>
        /// </item>
        /// <item>
        /// <description>Custom</description>
        /// </item>
        /// <item>
        /// <description>Warzone</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "gameMode")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.GameMode GameMode { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this playlist.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// An image used to illustrate this playlist.
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Indicates if this playlist is currently available for play.
        /// </summary>
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Indicates if a CSR (competitive skill rank) is shown for players who participate in this playlist.
        /// </summary>
        [JsonProperty(PropertyName = "isRanked")]
        public bool IsRanked { get; set; }

        /// <summary>
        /// A localized name for the playlist, suitable for display to users. The text is title cased.
        /// </summary>
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