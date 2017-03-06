using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Season
{
    [Serializable]
    public class Season : IEquatable<Season>
    {
        [JsonProperty(PropertyName = "StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        [JsonProperty(PropertyName = "Playlists")]
        public List<ContentItemTypeB<Playlist.View>> Playlists { get; set; }

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

            return Equals(DisplayInfo, other.DisplayInfo)
                && Equals(Image, other.Image)
                && Playlists.OrderBy(p => p.Id).SequenceEqual(other.Playlists.OrderBy(p => p.Id))
                && StartDate.Equals(other.StartDate);
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

            if (obj.GetType() != typeof(Season))
            {
                return false;
            }

            return Equals((Season) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Playlists?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ StartDate.GetHashCode();
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