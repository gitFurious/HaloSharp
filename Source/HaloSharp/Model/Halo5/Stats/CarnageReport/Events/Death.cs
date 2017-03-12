using System;
using System.Collections.Generic;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class Death : MatchEvent, IEquatable<Death>
    {
        [JsonProperty(PropertyName = "Assistants")]
        public List<Identity> Assistants { get; set; }

        [JsonProperty(PropertyName = "DeathDisposition")]
        public Enumeration.Halo5.Disposition DeathDisposition { get; set; }

        [JsonProperty(PropertyName = "IsAssassination")]
        public bool IsAssassination { get; set; }

        [JsonProperty(PropertyName = "IsGroundPound")]
        public bool IsGroundPound { get; set; }

        [JsonProperty(PropertyName = "IsHeadshot")]
        public bool IsHeadshot { get; set; }

        [JsonProperty(PropertyName = "IsMelee")]
        public bool IsMelee { get; set; }

        [JsonProperty(PropertyName = "IsShoulderBash")]
        public bool IsShoulderBash { get; set; }

        [JsonProperty(PropertyName = "IsWeapon")]
        public bool IsWeapon { get; set; }

        [JsonProperty(PropertyName = "Killer")]
        public Identity Killer { get; set; }

        [JsonProperty(PropertyName = "KillerAgent")]
        public Enumeration.Halo5.Agent KillerAgent { get; set; }

        [JsonProperty(PropertyName = "KillerWeaponAttachmentIds")]
        public List<uint> KillerWeaponAttachmentIds { get; set; }

        [JsonProperty(PropertyName = "KillerWeaponStockId")]
        public uint KillerWeaponStockId { get; set; }

        [JsonProperty(PropertyName = "KillerWorldLocation")]
        public Location KillerWorldLocation { get; set; }

        [JsonProperty(PropertyName = "Victim")]
        public Identity Victim { get; set; }

        [JsonProperty(PropertyName = "VictimAgent")]
        public Enumeration.Halo5.Agent VictimAgent { get; set; }

        [JsonProperty(PropertyName = "VictimAttachmentIds")]
        public List<uint> VictimAttachmentIds { get; set; }

        [JsonProperty(PropertyName = "VictimStockId")]
        public uint VictimStockId { get; set; }

        [JsonProperty(PropertyName = "VictimWorldLocation")]
        public Location VictimWorldLocation { get; set; }

        public bool Equals(Death other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Assistants, other.Assistants)
                   && DeathDisposition == other.DeathDisposition
                   && IsAssassination == other.IsAssassination
                   && IsGroundPound == other.IsGroundPound
                   && IsHeadshot == other.IsHeadshot
                   && IsMelee == other.IsMelee
                   && IsShoulderBash == other.IsShoulderBash
                   && IsWeapon == other.IsWeapon
                   && Equals(Killer, other.Killer)
                   && KillerAgent == other.KillerAgent
                   && Equals(KillerWeaponAttachmentIds, other.KillerWeaponAttachmentIds)
                   && KillerWeaponStockId == other.KillerWeaponStockId
                   && Equals(KillerWorldLocation, other.KillerWorldLocation)
                   && Equals(Victim, other.Victim)
                   && VictimAgent == other.VictimAgent
                   && Equals(VictimAttachmentIds, other.VictimAttachmentIds)
                   && VictimStockId == other.VictimStockId
                   && Equals(VictimWorldLocation, other.VictimWorldLocation);
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

            if (obj.GetType() != typeof(Death))
            {
                return false;
            }

            return Equals((Death)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Assistants?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (int)DeathDisposition;
                hashCode = (hashCode * 397) ^ IsAssassination.GetHashCode();
                hashCode = (hashCode * 397) ^ IsGroundPound.GetHashCode();
                hashCode = (hashCode * 397) ^ IsHeadshot.GetHashCode();
                hashCode = (hashCode * 397) ^ IsMelee.GetHashCode();
                hashCode = (hashCode * 397) ^ IsShoulderBash.GetHashCode();
                hashCode = (hashCode * 397) ^ IsWeapon.GetHashCode();
                hashCode = (hashCode * 397) ^ (Killer != null ? Killer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)KillerAgent;
                hashCode = (hashCode * 397) ^ (KillerWeaponAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)KillerWeaponStockId;
                hashCode = (hashCode * 397) ^ (KillerWorldLocation != null ? KillerWorldLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Victim != null ? Victim.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)VictimAgent;
                hashCode = (hashCode * 397) ^ (VictimAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)VictimStockId;
                hashCode = (hashCode * 397) ^ (VictimWorldLocation != null ? VictimWorldLocation.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Death left, Death right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Death left, Death right)
        {
            return !Equals(left, right);
        }
    }
}