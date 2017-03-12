using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class BuildingConstructionCompleted : MatchEvent, IEquatable<BuildingConstructionCompleted>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        public bool Equals(BuildingConstructionCompleted other)
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

            if (obj.GetType() != typeof(BuildingConstructionCompleted))
            {
                return false;
            }

            return Equals((BuildingConstructionCompleted)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (InstanceId * 397) ^ PlayerIndex;
            }
        }

        public static bool operator ==(BuildingConstructionCompleted left, BuildingConstructionCompleted right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BuildingConstructionCompleted left, BuildingConstructionCompleted right)
        {
            return !Equals(left, right);
        }
    }
}