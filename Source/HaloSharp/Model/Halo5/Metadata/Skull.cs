using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Skull : IEquatable<Skull>
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
        /// The ID that uniquely identifies this skull.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Indicates what mission this skull can be located within. Null when the skull is not found in a mission. 
        /// Missions are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "missionId")]
        public Guid? MissionId { get; set; }

        /// <summary>
        /// A localized name, suitable for display to users. The text is title cased.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public bool Equals(Skull other)
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
                && Id == other.Id
                && string.Equals(ImageUrl, other.ImageUrl)
                && MissionId.Equals(other.MissionId)
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

            if (obj.GetType() != typeof (Skull))
            {
                return false;
            }

            return Equals((Skull) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (ImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MissionId.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Skull left, Skull right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Skull left, Skull right)
        {
            return !Equals(left, right);
        }
    }
}