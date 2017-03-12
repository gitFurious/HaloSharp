using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class PointStatusChange : MatchEvent, IEquatable<PointStatusChange>
    {
        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public Enumeration.HaloWars2.PointStatus PointStatus { get; set; }

        [JsonProperty(PropertyName = "OwningTeamId")]
        public int OwningTeamId { get; set; }

        public bool Equals(PointStatusChange other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return InstanceId == other.InstanceId
                   && OwningTeamId == other.OwningTeamId
                   && PointStatus == other.PointStatus;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(PointStatusChange))
            {
                return false;
            }

            return Equals((PointStatusChange)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = InstanceId;
                hashCode = (hashCode * 397) ^ OwningTeamId;
                hashCode = (hashCode * 397) ^ (int)PointStatus;
                return hashCode;
            }
        }

        public static bool operator ==(PointStatusChange left, PointStatusChange right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PointStatusChange left, PointStatusChange right)
        {
            return !Equals(left, right);
        }
    }
}