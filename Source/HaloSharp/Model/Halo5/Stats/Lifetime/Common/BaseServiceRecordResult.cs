using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime.Common
{
    [Serializable]
    public class BaseServiceRecordResult : IEquatable<BaseServiceRecordResult>
    {
        /// <summary>
        /// The player's gamertag.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// The result of the query for the player. One of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>Success = 0</description>
        /// </item>
        /// <item>
        /// <description>NotFound = 1</description>
        /// </item>
        /// <item>
        /// <description>ServiceFailure = 2</description>
        /// </item>
        /// <item>
        /// <description>ServiceUnavailable = 3</description>
        /// </item>
        /// </list>
        /// It is possible for different requests from the batch to succeed and fail independently.
        /// </summary>
        [JsonProperty(PropertyName = "ResultCode")]
        public Enumeration.Common.QueryResult ResultCode { get; set; }

        public bool Equals(BaseServiceRecordResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Id, other.Id)
                && ResultCode == other.ResultCode;
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

            if (obj.GetType() != typeof (BaseServiceRecordResult))
            {
                return false;
            }

            return Equals((BaseServiceRecordResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id?.GetHashCode() ?? 0)*397) ^ (int) ResultCode;
            }
        }

        public static bool operator ==(BaseServiceRecordResult left, BaseServiceRecordResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseServiceRecordResult left, BaseServiceRecordResult right)
        {
            return !Equals(left, right);
        }
    }
}