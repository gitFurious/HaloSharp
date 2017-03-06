using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class BuildingConstructionQueued : MatchEvent, IEquatable<BuildingConstructionQueued>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "BuildingId")]
        public string BuildingId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        [JsonProperty(PropertyName = "QueueLength")]
        public int QueueLength { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(BuildingConstructionQueued other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return string.Equals(BuildingId, other.BuildingId)
                   && EnergyCost == other.EnergyCost
                   && InstanceId == other.InstanceId
                   && Equals(Location, other.Location)
                   && PlayerIndex == other.PlayerIndex
                   && ProvidedByScenario == other.ProvidedByScenario
                   && QueueLength == other.QueueLength
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

            if (obj.GetType() != typeof(BuildingConstructionQueued))
            {
                return false;
            }

            return Equals((BuildingConstructionQueued)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BuildingId?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ EnergyCost;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ ProvidedByScenario.GetHashCode();
                hashCode = (hashCode * 397) ^ QueueLength;
                hashCode = (hashCode * 397) ^ SupplyCost;
                return hashCode;
            }
        }

        public static bool operator ==(BuildingConstructionQueued left, BuildingConstructionQueued right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BuildingConstructionQueued left, BuildingConstructionQueued right)
        {
            return !Equals(left, right);
        }
    }
}