using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class GameBaseVariant : IEquatable<GameBaseVariant>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// An image to use as the game base variant for the designation.
        /// </summary>
        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this game base variant.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Internal use. The internal non-localized name for the the game base variant.
        /// </summary>
        [JsonProperty(PropertyName = "internalName")]
        public string InternalName { get; set; }

        /// <summary>
        /// A localized name for the game base variant, suitable for display to users. The text is title cased.
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

        public bool Equals(GameBaseVariant other)
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
                && string.Equals(IconUrl, other.IconUrl)
                && Id.Equals(other.Id)
                && string.Equals(InternalName, other.InternalName)
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

            if (obj.GetType() != typeof (GameBaseVariant))
            {
                return false;
            }

            return Equals((GameBaseVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (InternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SupportedGameModes?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameBaseVariant left, GameBaseVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameBaseVariant left, GameBaseVariant right)
        {
            return !Equals(left, right);
        }
    }
}