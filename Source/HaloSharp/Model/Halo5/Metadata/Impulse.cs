using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Impulse : IEquatable<Impulse>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this impulse.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>
        /// Internal use. The non-localized name of the impulse.
        /// </summary>
        [JsonProperty(PropertyName = "internalName")]
        public string InternalName { get; set; }

        public bool Equals(Impulse other)
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
                && Id == other.Id
                && string.Equals(InternalName, other.InternalName);
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

            if (obj.GetType() != typeof (Impulse))
            {
                return false;
            }

            return Equals((Impulse) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ (InternalName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Impulse left, Impulse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Impulse left, Impulse right)
        {
            return !Equals(left, right);
        }
    }
}