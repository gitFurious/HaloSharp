using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class UnitPromoted : MatchEvent, IEquatable<UnitPromoted>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "SquadId")]
        public string SquadId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        public bool Equals(UnitPromoted other)
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
                   && PlayerIndex == other.PlayerIndex
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

            if (obj.GetType() != typeof(UnitPromoted))
            {
                return false;
            }

            return Equals((UnitPromoted)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = InstanceId;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ (SquadId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(UnitPromoted left, UnitPromoted right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitPromoted left, UnitPromoted right)
        {
            return !Equals(left, right);
        }
    }
}