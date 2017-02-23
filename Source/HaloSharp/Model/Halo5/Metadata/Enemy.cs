using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Enemy : IEquatable<Enemy>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// A localized description, suitable for display to users. Note: This may be null.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The faction that this enemy is affiliated with. One of the following options:
        /// <list type="bullet">
        /// <item>
        /// <description>UNSC</description>
        /// </item>
        /// <item>
        /// <description>Covenant</description>
        /// </item>
        /// <item>
        /// <description>Promethean</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "faction")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Faction Faction { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this enemy.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

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

        public bool Equals(Enemy other)
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
                && Faction == other.Faction && Id == other.Id
                && string.Equals(LargeIconImageUrl, other.LargeIconImageUrl) 
                && string.Equals(Name, other.Name)
                && string.Equals(SmallIconImageUrl, other.SmallIconImageUrl)
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

            if (obj.GetType() != typeof (Enemy))
            {
                return false;
            }

            return Equals((Enemy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) Faction;
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ (LargeIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Enemy left, Enemy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enemy left, Enemy right)
        {
            return !Equals(left, right);
        }
    }
}