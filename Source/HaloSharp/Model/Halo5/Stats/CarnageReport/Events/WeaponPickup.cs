using System;
using System.Collections.Generic;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class WeaponPickup : MatchEvent, IEquatable<WeaponPickup>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        [JsonProperty(PropertyName = "WeaponAttachmentIds")]
        public List<uint> WeaponAttachmentIds { get; set; }

        [JsonProperty(PropertyName = "WeaponStockId")]
        public uint WeaponStockId { get; set; }

        public bool Equals(WeaponPickup other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Player, other.Player)
                   && Equals(WeaponAttachmentIds, other.WeaponAttachmentIds)
                   && WeaponStockId == other.WeaponStockId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(WeaponPickup))
            {
                return false;
            }

            return Equals((WeaponPickup)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Player != null ? Player.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (WeaponAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)WeaponStockId;
                return hashCode;
            }
        }

        public static bool operator ==(WeaponPickup left, WeaponPickup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeaponPickup left, WeaponPickup right)
        {
            return !Equals(left, right);
        }
    }
}