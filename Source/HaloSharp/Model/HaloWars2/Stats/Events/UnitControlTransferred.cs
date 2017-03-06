using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class UnitControlTransferred : MatchEvent, IEquatable<UnitControlTransferred>
    {
        [JsonProperty(PropertyName = "OldPlayerIndex")]
        public int OldPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "NewPlayerIndex")]
        public int NewPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "SquadId")]
        public string SquadId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "CapturerInstanceId")]
        public int CapturerInstanceId { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "PopulationCost")]
        public int PopulationCost { get; set; }

        public bool Equals(UnitControlTransferred other)
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
                   && InstanceId == other.InstanceId
                   && Equals(Location, other.Location)
                   && NewPlayerIndex == other.NewPlayerIndex
                   && OldPlayerIndex == other.OldPlayerIndex
                   && PopulationCost == other.PopulationCost
                   && string.Equals(SquadId, other.SquadId);
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

            if (obj.GetType() != typeof(UnitControlTransferred))
            {
                return false;
            }

            return Equals((UnitControlTransferred)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CapturerInstanceId;
                hashCode = (hashCode * 397) ^ InstanceId;
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NewPlayerIndex;
                hashCode = (hashCode * 397) ^ OldPlayerIndex;
                hashCode = (hashCode * 397) ^ PopulationCost;
                hashCode = (hashCode * 397) ^ (SquadId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(UnitControlTransferred left, UnitControlTransferred right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitControlTransferred left, UnitControlTransferred right)
        {
            return !Equals(left, right);
        }
    }
}