using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class LeaderPowerCast : MatchEvent, IEquatable<LeaderPowerCast>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "PowerId")]
        public string PowerId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "TargetLocation")]
        public Location TargetLocation { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        public bool Equals(LeaderPowerCast other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return EnergyCost == other.EnergyCost
                   && InstanceId == other.InstanceId
                   && PlayerIndex == other.PlayerIndex
                   && string.Equals(PowerId, other.PowerId)
                   && SupplyCost == other.SupplyCost
                   && Equals(TargetLocation, other.TargetLocation);
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

            if (obj.GetType() != typeof(LeaderPowerCast))
            {
                return false;
            }

            return Equals((LeaderPowerCast)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EnergyCost;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ (PowerId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ SupplyCost;
                hashCode = (hashCode * 397) ^ (TargetLocation != null ? TargetLocation.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(LeaderPowerCast left, LeaderPowerCast right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeaderPowerCast left, LeaderPowerCast right)
        {
            return !Equals(left, right);
        }
    }
}