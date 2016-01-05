using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class MapVariant : IEquatable<MapVariant>
    {
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
        /// The ID that uniquely identifies this map variant.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the map this is a variant for. Maps are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "mapId")]
        public Guid? MapId { get; set; }

        /// <summary>
        /// A reference to an image. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "mapImageUrl")]
        public string MapImageUrl { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public bool Equals(MapVariant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ContentId.Equals(other.ContentId)
                && string.Equals(Description, other.Description)
                && Id.Equals(other.Id)
                && MapId.Equals(other.MapId)
                && string.Equals(MapImageUrl, other.MapImageUrl)
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

            if (obj.GetType() != typeof (MapVariant))
            {
                return false;
            }

            return Equals((MapVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ (MapImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(MapVariant left, MapVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MapVariant left, MapVariant right)
        {
            return !Equals(left, right);
        }
    }
}