using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Season : IEquatable<Season>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The end date and time of this season.
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// An icon used to represent this season.
        /// </summary>
        [JsonProperty(PropertyName = "iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this season.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates if this season is currently active.
        /// </summary>
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// A localized name for the season, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// One or more playlists that are available in this season.
        /// </summary>
        [JsonProperty(PropertyName = "playlists")]
        public List<Playlist> Playlists { get; set; }

        /// <summary>
        /// The start date and time of this season.
        /// </summary>
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