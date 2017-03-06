using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class ResourceTransferred : MatchEvent, IEquatable<ResourceTransferred>
    {
        [JsonProperty(PropertyName = "SendingPlayerIndex")]
        public int SendingPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "ReceivingPlayerIndex")]
        public int ReceivingPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        [JsonProperty(PropertyName = "SupplyEarned")]
        public int SupplyEarned { get; set; }

        [JsonProperty(PropertyName = "EnergyEarned")]
        public int EnergyEarned { get; set; }

        public bool Equals(ResourceTransferred other)
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
                   && EnergyEarned == other.EnergyEarned
                   && ReceivingPlayerIndex == other.ReceivingPlayerIndex
                   && SendingPlayerIndex == other.SendingPlayerIndex
                   && SupplyCost == other.SupplyCost
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

            if (obj.GetType() != typeof(ResourceTransferred))
            {
                return false;
            }

            return Equals((ResourceTransferred)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EnergyCost;
                hashCode = (hashCode * 397) ^ EnergyEarned;
                hashCode = (hashCode * 397) ^ ReceivingPlayerIndex;
                hashCode = (hashCode * 397) ^ SendingPlayerIndex;
                hashCode = (hashCode * 397) ^ SupplyCost;
                hashCode = (hashCode * 397) ^ SupplyEarned;
                return hashCode;
            }
        }

        public static bool operator ==(ResourceTransferred left, ResourceTransferred right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResourceTransferred left, ResourceTransferred right)
        {
            return !Equals(left, right);
        }
    }
}