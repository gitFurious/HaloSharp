using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Map : IEquatable<Map>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "supportedGameModes", ItemConverterType = typeof(StringEnumConverter))]
        public List<Enumeration.Halo5.GameMode> SupportedGameModes { get; set; }

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