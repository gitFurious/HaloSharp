using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Link : IEquatable<Link>
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "AcknowledgementTypeId")]
        public int AcknowledgementTypeId { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "AuthenticationLifetimeExtensionSupported")]
        public bool AuthenticationLifetimeExtensionSupported { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "AuthorityId")]
        public string AuthorityId { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "Path")]
        public string Path { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "QueryString")]
        public object QueryString { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "RetryPolicyId")]
        public string RetryPolicyId { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "TopicName")]
        public string TopicName { get; set; }

        public bool Equals(Link other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return AcknowledgementTypeId == other.AcknowledgementTypeId
                && AuthenticationLifetimeExtensionSupported == other.AuthenticationLifetimeExtensionSupported
                && string.Equals(AuthorityId, other.AuthorityId)
                && string.Equals(Path, other.Path)
                && Equals(QueryString, other.QueryString)
                && string.Equals(RetryPolicyId, other.RetryPolicyId)
                && string.Equals(TopicName, other.TopicName);
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

            if (obj.GetType() != typeof (Link))
            {
                return false;
            }

            return Equals((Link) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AcknowledgementTypeId;
                hashCode = (hashCode*397) ^ AuthenticationLifetimeExtensionSupported.GetHashCode();
                hashCode = (hashCode*397) ^ (AuthorityId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Path?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (QueryString?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RetryPolicyId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TopicName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Link left, Link right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Link left, Link right)
        {
            return !Equals(left, right);
        }
    }
}