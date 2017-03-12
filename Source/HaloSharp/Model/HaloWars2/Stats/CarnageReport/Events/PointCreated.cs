using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class PointCreated : MatchEvent, IEquatable<PointCreated>
    {
        [JsonProperty(PropertyName = "PointId")]
        public string PointId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public Location Location { get; set; }

        public bool Equals(PointCreated other)
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
                   && Equals(Location, other.Location)
                   && string.Equals(PointId, other.PointId);
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

            if (obj.GetType() != typeof(PointCreated))
            {
                return false;
            }

            return Equals((PointCreated)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = InstanceId;
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PointId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(PointCreated left, PointCreated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PointCreated left, PointCreated right)
        {
            return !Equals(left, right);
        }
    }
}