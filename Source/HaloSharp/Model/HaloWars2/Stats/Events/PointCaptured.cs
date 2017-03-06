using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class PointCaptured : MatchEvent, IEquatable<PointCaptured>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "CapturerInstanceId")]
        public int CapturerInstanceId { get; set; }

        [JsonProperty(PropertyName = "CapturerLocation")]
        public Location CapturerLocation { get; set; }

        [JsonProperty(PropertyName = "NewOwningTeamId")]
        public int NewOwningTeamId { get; set; }

        public bool Equals(PointCaptured other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CapturerInstanceId == other.CapturerInstanceId
                   && Equals(CapturerLocation, other.CapturerLocation)
                   && InstanceId == other.InstanceId
                   && NewOwningTeamId == other.NewOwningTeamId
                   && PlayerIndex == other.PlayerIndex;
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

            if (obj.GetType() != typeof(PointCaptured))
            {
                return false;
            }

            return Equals((PointCaptured)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CapturerInstanceId;
                hashCode = (hashCode * 397) ^ (CapturerLocation != null ? CapturerLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ NewOwningTeamId;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                return hashCode;
            }
        }

        public static bool operator ==(PointCaptured left, PointCaptured right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PointCaptured left, PointCaptured right)
        {
            return !Equals(left, right);
        }
    }
}