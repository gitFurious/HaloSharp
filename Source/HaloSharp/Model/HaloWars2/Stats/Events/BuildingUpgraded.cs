using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class BuildingUpgraded : MatchEvent, IEquatable<BuildingUpgraded>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "NewBuildingId")]
        public string NewBuildingId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        public bool Equals(BuildingUpgraded other)
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
                   && string.Equals(NewBuildingId, other.NewBuildingId)
                   && PlayerIndex == other.PlayerIndex
                   && SupplyCost == other.SupplyCost;
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

            if (obj.GetType() != typeof(BuildingUpgraded))
            {
                return false;
            }

            return Equals((BuildingUpgraded)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EnergyCost;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ (NewBuildingId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ SupplyCost;
                return hashCode;
            }
        }

        public static bool operator ==(BuildingUpgraded left, BuildingUpgraded right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BuildingUpgraded left, BuildingUpgraded right)
        {
            return !Equals(left, right);
        }
    }
}