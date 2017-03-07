using System;
using System.Collections.Generic;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class WeaponDrop : MatchEvent, IEquatable<WeaponDrop>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        [JsonProperty(PropertyName = "ShotsFired")]
        public int ShotsFired { get; set; }

        [JsonProperty(PropertyName = "ShotsLanded")]
        public int ShotsLanded { get; set; }

        [JsonProperty(PropertyName = "TimeWeaponActiveAsPrimary")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeWeaponActiveAsPrimary { get; set; }

        [JsonProperty(PropertyName = "WeaponAttachmentIds")]
        public List<uint> WeaponAttachmentIds { get; set; }

        [JsonProperty(PropertyName = "WeaponStockId")]
        public uint WeaponStockId { get; set; }

        public bool Equals(WeaponDrop other)
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
                   && ShotsFired == other.ShotsFired
                   && ShotsLanded == other.ShotsLanded
                   && TimeWeaponActiveAsPrimary.Equals(other.TimeWeaponActiveAsPrimary)
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

            if (obj.GetType() != typeof(WeaponDrop))
            {
                return false;
            }

            return Equals((WeaponDrop)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Player != null ? Player.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShotsFired;
                hashCode = (hashCode * 397) ^ ShotsLanded;
                hashCode = (hashCode * 397) ^ TimeWeaponActiveAsPrimary.GetHashCode();
                hashCode = (hashCode * 397) ^ (WeaponAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)WeaponStockId;
                return hashCode;
            }
        }

        public static bool operator ==(WeaponDrop left, WeaponDrop right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeaponDrop left, WeaponDrop right)
        {
            return !Equals(left, right);
        }
    }
}