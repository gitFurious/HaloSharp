using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Image
{
    [Serializable]
    public class Media : IEquatable<Media>
    {
        [JsonProperty(PropertyName = "MediaUrl")]
        public string MediaUrl { get; set; }

        [JsonProperty(PropertyName = "MimeType")]
        public string MimeType { get; set; }

        [JsonProperty(PropertyName = "Caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "AlternateText")]
        public string AlternateText { get; set; }

        [JsonProperty(PropertyName = "FolderPath")]
        public string FolderPath { get; set; }

        [JsonProperty(PropertyName = "FileName")]
        public string FileName { get; set; }

        public bool Equals(Media other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(MediaUrl, other.MediaUrl)
                && string.Equals(MimeType, other.MimeType)
                && string.Equals(Caption, other.Caption)
                && string.Equals(AlternateText, other.AlternateText)
                && string.Equals(FolderPath, other.FolderPath)
                && string.Equals(FileName, other.FileName);
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

            if (obj.GetType() != typeof(Media))
            {
                return false;
            }

            return Equals((Media) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MediaUrl?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (MimeType?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Caption?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (AlternateText?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (FolderPath?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (FileName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Media left, Media right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Media left, Media right)
        {
            return !Equals(left, right);
        }
    }
}