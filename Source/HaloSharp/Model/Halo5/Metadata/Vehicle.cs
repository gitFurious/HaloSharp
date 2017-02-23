using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Vehicle : IEquatable<Vehicle>
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
        /// The ID that uniquely identifies this vehicle.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>
        /// Indicates whether the vehicle is usable by a player.
        /// </summary>
        [JsonProperty(PropertyName = "isUsableByPlayer")]
        public bool IsUsableByPlayer { get; set; }

        /// <summary>
        /// A reference to a large image for icon use. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "largeIconImageUrl")]
        public string LargeIconImageUrl { get; set; }

        /// <summary>
        /// A localized name for the object, suitable for display to users. The text is title cased.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A reference to a small image for icon use. This may be null if there is no image defined.
        /// </summary>
        [JsonProperty(PropertyName = "smallIconImageUrl")]
        public string SmallIconImageUrl { get; set; }

        public bool Equals(Vehicle other)
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
                && IsUsableByPlayer == other.IsUsableByPlayer
                && string.Equals(LargeIconImageUrl, other.LargeIconImageUrl)
                && string.Equals(Name, other.Name)
                && string.Equals(SmallIconImageUrl, other.SmallIconImageUrl);
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

            if (obj.GetType() != typeof (Vehicle))
            {
                return false;
            }

            return Equals((Vehicle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ IsUsableByPlayer.GetHashCode();
                hashCode = (hashCode*397) ^ (LargeIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallIconImageUrl?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Vehicle left, Vehicle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Vehicle left, Vehicle right)
        {
            return !Equals(left, right);
        }
    }
}