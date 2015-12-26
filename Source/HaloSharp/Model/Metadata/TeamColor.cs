using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class TeamColor : IEquatable<TeamColor>
    {
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

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