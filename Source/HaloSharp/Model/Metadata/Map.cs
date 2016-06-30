using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Map : IEquatable<Map>
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
        /// The ID that uniquely identifies this map.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// A reference to an image. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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
        [JsonProperty(PropertyName = "supportedGameModes", ItemConverterType = typeof(StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        public bool Equals(Map other)
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
                && string.Equals(ImageUrl, other.ImageUrl) 
                && string.Equals(Name, other.Name)
                && ((SupportedGameModes == null && other.SupportedGameModes == null) || (SupportedGameModes != null && other.SupportedGameModes != null && SupportedGameModes.OrderBy(ka => ka).SequenceEqual(other.SupportedGameModes.OrderBy(ka => ka))));
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

            if (obj.GetType() != typeof (Map))
            {
                return false;
            }

            return Equals((Map) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (ImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SupportedGameModes?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Map left, Map right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Map left, Map right)
        {
            return !Equals(left, right);
        }
    }
}