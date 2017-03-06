using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class UnitTrained : MatchEvent, IEquatable<UnitTrained>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "SquadId")]
        public string SquadId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "CreatorInstanceId")]
        public int CreatorInstanceId { get; set; }

        [JsonProperty(PropertyName = "SpawnLocation")]
        public Location SpawnLocation { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        [JsonProperty(PropertyName = "PopulationCost")]
        public int PopulationCost { get; set; }

        [JsonProperty(PropertyName = "IsClone")]
        public bool IsClone { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(UnitTrained other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CreatorInstanceId == other.CreatorInstanceId
                   && EnergyCost == other.EnergyCost
                   && InstanceId == other.InstanceId
                   && IsClone == other.IsClone
                   && PlayerIndex == other.PlayerIndex
                   && PopulationCost == other.PopulationCost
                   && ProvidedByScenario == other.ProvidedByScenario
                   && Equals(SpawnLocation, other.SpawnLocation)
                   && string.Equals(SquadId, other.SquadId)
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

            if (obj.GetType() != typeof(UnitTrained))
            {
                return false;
            }

            return Equals((UnitTrained)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CreatorInstanceId;
                hashCode = (hashCode * 397) ^ EnergyCost;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ IsClone.GetHashCode();
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ PopulationCost;
                hashCode = (hashCode * 397) ^ ProvidedByScenario.GetHashCode();
                hashCode = (hashCode * 397) ^ (SpawnLocation != null ? SpawnLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SquadId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ SupplyCost;
                return hashCode;
            }
        }

        public static bool operator ==(UnitTrained left, UnitTrained right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitTrained left, UnitTrained right)
        {
            return !Equals(left, right);
        }
    }
}