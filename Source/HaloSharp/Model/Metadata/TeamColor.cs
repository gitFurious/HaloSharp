using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class TeamColor : IEquatable<TeamColor>
    {
        /// <summary>
        /// A seven-character string representing the team color in "RGB Hex" notation. This notation uses a "#" 
        /// followed by a hex triplet.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

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
        /// A reference to an image for icon use. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this color. This will be the same as the team's ID in responses from the 
        /// Stats API.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public bool Equals(TeamColor other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Color, other.Color)
                && ContentId.Equals(other.ContentId)
                && string.Equals(Description, other.Description)
                && string.Equals(IconUrl, other.IconUrl)
                && Id == other.Id && string.Equals(Name, other.Name);
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

            if (obj.GetType() != typeof (TeamColor))
            {
                return false;
            }

            return Equals((TeamColor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Color?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(TeamColor left, TeamColor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamColor left, TeamColor right)
        {
            return !Equals(left, right);
        }
    }
}