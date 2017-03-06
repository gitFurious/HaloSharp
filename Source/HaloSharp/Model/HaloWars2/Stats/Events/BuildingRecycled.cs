using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class BuildingRecycled : MatchEvent, IEquatable<BuildingRecycled>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "SupplyEarned")]
        public int SupplyEarned { get; set; }

        [JsonProperty(PropertyName = "EnergyEarned")]
        public int EnergyEarned { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(BuildingRecycled other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return EnergyEarned == other.EnergyEarned
                   && InstanceId == other.InstanceId
                   && PlayerIndex == other.PlayerIndex
                   && ProvidedByScenario == other.ProvidedByScenario
                   && SupplyEarned == other.SupplyEarned;
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

            if (obj.GetType() != typeof(BuildingRecycled))
            {
                return false;
            }

            return Equals((BuildingRecycled)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EnergyEarned;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ ProvidedByScenario.GetHashCode();
                hashCode = (hashCode * 397) ^ SupplyEarned;
                return hashCode;
            }
        }

        public static bool operator ==(BuildingRecycled left, BuildingRecycled right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BuildingRecycled left, BuildingRecycled right)
        {
            return !Equals(left, right);
        }
    }
}