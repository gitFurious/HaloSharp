using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Season : IEquatable<Season>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "playlists")]
        public List<Playlist> Playlists { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime? StartDate { get; set; }

        public bool Equals(Season other)
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
                && EndDate.Equals(other.EndDate)
                && string.Equals(IconUrl, other.IconUrl)
                && Id.Equals(other.Id)
                && IsActive == other.IsActive
                && string.Equals(Name, other.Name)
                && Playlists.OrderBy(p => p.Id).SequenceEqual(other.Playlists.OrderBy(p => p.Id))
                && string.Equals(StartDate, other.StartDate);
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

            if (obj.GetType() != typeof (Season))
            {
                return false;
            }

            return Equals((Season) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ EndDate.GetHashCode();
                hashCode = (hashCode*397) ^ (IconUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ IsActive.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Playlists?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (StartDate?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Season left, Season right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Season left, Season right)
        {
            return !Equals(left, right);
        }
    }
}