using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class FlexibleStat : IEquatable<FlexibleStat>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this stat.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// A localized name for the data point, suitable for display to users. The text is title cased.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of stat this represents, it is one of the following options:
        /// <list type="bullet">
        /// <item>
        /// <description>Count</description>
        /// </item>
        /// <item>
        /// <description>Duration</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.FlexibleStatType Type { get; set; }

        public bool Equals(FlexibleStat other)
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
                && Id.Equals(other.Id) 
                && string.Equals(Name, other.Name) 
                && Type == other.Type;
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

            if (obj.GetType() != typeof (FlexibleStat))
            {
                return false;
            }

            return Equals((FlexibleStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public static bool operator ==(FlexibleStat left, FlexibleStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FlexibleStat left, FlexibleStat right)
        {
            return !Equals(left, right);
        }
    }
}