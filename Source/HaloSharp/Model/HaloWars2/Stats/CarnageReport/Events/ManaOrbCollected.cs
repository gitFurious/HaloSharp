using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class ManaOrbCollected : MatchEvent, IEquatable<ManaOrbCollected>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "CollectorInstanceId")]
        public int CollectorInstanceId { get; set; }

        [JsonProperty(PropertyName = "ManaRateIncrease")]
        public int ManaRateIncrease { get; set; }

        [JsonProperty(PropertyName = "Location")]
        public Location Location { get; set; }

        public bool Equals(ManaOrbCollected other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CollectorInstanceId == other.CollectorInstanceId
                   && Equals(Location, other.Location)
                   && ManaRateIncrease == other.ManaRateIncrease
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

            if (obj.GetType() != typeof(ManaOrbCollected))
            {
                return false;
            }

            return Equals((ManaOrbCollected)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CollectorInstanceId;
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ManaRateIncrease;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                return hashCode;
            }
        }

        public static bool operator ==(ManaOrbCollected left, ManaOrbCollected right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ManaOrbCollected left, ManaOrbCollected right)
        {
            return !Equals(left, right);
        }
    }
}