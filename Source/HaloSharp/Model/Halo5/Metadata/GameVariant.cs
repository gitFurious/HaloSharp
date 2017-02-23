using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class GameVariant : IEquatable<GameVariant>
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
        /// The ID of the game base variant this is a variant for. Game Base Variants are available via the Metadata 
        /// API.
        /// </summary>
        [JsonProperty(PropertyName = "gameBaseVariantId")]
        public Guid? GameBaseVariantId { get; set; }

        /// <summary>
        /// An icon image for the game variant.
        /// </summary>
        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this game variant.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public bool Equals(GameVariant other)
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
                && GameBaseVariantId.Equals(other.GameBaseVariantId)
                && string.Equals(IconUrl, other.IconUrl)
                && Id.Equals(other.Id)
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

            if (obj.GetType() != typeof (GameVariant))
            {
                return false;
            }

            return Equals((GameVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameVariant left, GameVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameVariant left, GameVariant right)
        {
            return !Equals(left, right);
        }
    }
}