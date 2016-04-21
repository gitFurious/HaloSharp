using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class MatchEvents : IEquatable<MatchEvents>
    {
        /// <summary>
        ///     Internal use only. A set of related resource links.
        /// </summary>
        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        /// <summary>
        ///     An ordered list of events that describe a match from start to completion. Events can be a variety of types which
        ///     will influence what fields are filled in.
        /// </summary>
        [JsonProperty(PropertyName = "GameEvents")]
        public List<GameEvent> GameEvents { get; set; }

        /// <summary>
        ///     As this is an experimental API it has no guarantees around its accuracy. However we do try our best to ensure all
        ///     events are valid and accounted for. If they do not match up to our expectations this field will return as false
        ///     indicating this may not be the full set of events that occurred in game.
        /// </summary>
        [JsonProperty(PropertyName = "IsCompleteSetOfEvents")]
        public bool IsCompleteSetOfEvents { get; set; }

        public bool Equals(MatchEvents other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && GameEvents.OrderBy(ge => ge.TimeSinceStart).SequenceEqual(other.GameEvents.OrderBy(ge => ge.TimeSinceStart))
                && IsCompleteSetOfEvents == other.IsCompleteSetOfEvents;
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

            if (obj.GetType() != typeof (MatchEvents))
            {
                return false;
            }

            return Equals((MatchEvents) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Links?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (GameEvents?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsCompleteSetOfEvents.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(MatchEvents left, MatchEvents right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchEvents left, MatchEvents right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class GameEvent : IEquatable<GameEvent>
    {
        /// <summary>
        ///     The gamertags of players who contributed to a kill.
        /// </summary>
        [JsonProperty(PropertyName = "Assistants")]
        public List<Identity> Assistants { get; set; }

        /// <summary>
        ///     The disposition of the death. Can be one of the following:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>Friendly = 0</description>
        ///         </item>
        ///         <item>
        ///             <description>Hostile = 1</description>
        ///         </item>
        ///         <item>
        ///             <description>Neutral = 2</description>
        ///         </item>
        ///     </list>
        /// </summary>
        [JsonProperty(PropertyName = "DeathDisposition")]
        public Enumeration.Disposition? DeathDisposition { get; set; }

        /// <summary>
        ///     The ID that uniquely identifies this impulse. Impulses are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "ImpulseId")]
        public uint? ImpulseId { get; set; }

        /// <summary>
        ///     Describes if the death was committed by the killer from behind (Assassination or melee to back).
        /// </summary>
        [JsonProperty(PropertyName = "IsAssassination")]
        public bool? IsAssassination { get; set; }

        /// <summary>
        ///     Describes if the kill was committed by the killer with a ground pound.
        /// </summary>
        [JsonProperty(PropertyName = "IsGroundPound")]
        public bool? IsGroundPound { get; set; }

        /// <summary>
        ///     Describes if the kill was committed by the killer with a head shot.
        /// </summary>
        [JsonProperty(PropertyName = "IsHeadshot")]
        public bool? IsHeadshot { get; set; }

        /// <summary>
        ///     Describes if the kill was committed by the killer using melee.
        /// </summary>
        [JsonProperty(PropertyName = "IsMelee")]
        public bool? IsMelee { get; set; }

        /// <summary>
        ///     Describes if the kill was committed by the killer with a shoulder bash.
        /// </summary>
        [JsonProperty(PropertyName = "IsShoulderBash")]
        public bool? IsShoulderBash { get; set; }

        /// <summary>
        ///     Describes if the kill was committed by the killer with a weapon.
        /// </summary>
        [JsonProperty(PropertyName = "IsWeapon")]
        public bool? IsWeapon { get; set; }

        /// <summary>
        ///     Describes the killer's information. Can be null if killer is not a player in the game.
        /// </summary>
        [JsonProperty(PropertyName = "Killer")]
        public Identity Killer { get; set; }

        /// <summary>
        ///     The type of killer that caused the death. Can be one of the following:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>None = 0</description>
        ///         </item>
        ///         <item>
        ///             <description>Player = 1</description>
        ///         </item>
        ///         <item>
        ///             <description>AI = 2</description>
        ///         </item>
        ///     </list>
        /// </summary>
        [JsonProperty(PropertyName = "KillerAgent")]
        public Enumeration.Agent? KillerAgent { get; set; }

        /// <summary>
        ///     Any attachments the killer's weapon had.
        /// </summary>
        [JsonProperty(PropertyName = "KillerWeaponAttachmentIds")]
        public List<uint> KillerWeaponAttachmentIds { get; set; }

        /// <summary>
        ///     The ID of the weapon. Weapons are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "KillerWeaponStockId")]
        public uint? KillerWeaponStockId { get; set; }

        /// <summary>
        ///     Object describing the position of the killer on the map when they made the kill.
        /// </summary>
        [JsonProperty(PropertyName = "KillerWorldLocation")]
        public WorldLocation KillerWorldLocation { get; set; }

        /// <summary>
        ///     The ID that uniquely identifies this medal. Medals are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "MedalId")]
        public uint? MedalId { get; set; }

        /// <summary>
        ///     The player.
        /// </summary>
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        /// <summary>
        ///     The index of the round that started.
        /// </summary>
        [JsonProperty(PropertyName = "RoundIndex")]
        public int? RoundIndex { get; set; }

        /// <summary>
        ///     The number of shots fired with the weapon by the player.
        /// </summary>
        [JsonProperty(PropertyName = "ShotsFired")]
        public int? ShotsFired { get; set; }

        /// <summary>
        ///     The number of shots that hit the target with the weapon by the player.
        /// </summary>
        [JsonProperty(PropertyName = "ShotsLanded")]
        public int? ShotsLanded { get; set; }

        /// <summary>
        ///     The amount of time the weapon was in the active slot of the player. This is expressed as an ISO 8601 Duration.
        /// </summary>
        [JsonProperty(PropertyName = "TimeWeaponActiveAsPrimary")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? TimeWeaponActiveAsPrimary { get; set; }

        /// <summary>
        ///     Describes the victim's information. Can be null if victim is not a player in the game.
        /// </summary>
        [JsonProperty(PropertyName = "Victim")]
        public Identity Victim { get; set; }

        /// <summary>
        ///     The type of victim who was killed. Can be one of the following:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>None = 0</description>
        ///         </item>
        ///         <item>
        ///             <description>Player = 1</description>
        ///         </item>
        ///         <item>
        ///             <description>AI = 2</description>
        ///         </item>
        ///     </list>
        /// </summary>
        [JsonProperty(PropertyName = "VictimAgent")]
        public Enumeration.Agent? VictimAgent { get; set; }

        /// <summary>
        ///     Any attachments the victim's weapon had.
        /// </summary>
        [JsonProperty(PropertyName = "VictimAttachmentIds")]
        public List<uint> VictimAttachmentIds { get; set; }

        /// <summary>
        ///     The ID of the weapon. Weapons are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "VictimStockId")]
        public uint? VictimStockId { get; set; }

        /// <summary>
        ///     Object describing the position of the victim on the map when they were killed.
        /// </summary>
        [JsonProperty(PropertyName = "VictimWorldLocation")]
        public WorldLocation VictimWorldLocation { get; set; }

        /// <summary>
        ///     The IDs of any attachments that were associated with the weapon that was picked up/dropped.
        /// </summary>
        [JsonProperty(PropertyName = "WeaponAttachmentIds")]
        public List<uint> WeaponAttachmentIds { get; set; }

        /// <summary>
        ///     The ID of the weapon that was picked up/dropped. Weapons are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "WeaponStockId")]
        public uint? WeaponStockId { get; set; }

        /// <summary>
        ///     Descriptor to determine what fields will be filled in for the event. This list will grow over time as more events 
        ///     are exposed. Can be one of the following:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>Death: An event that is created when a death occurs in the match.</description>
        ///         </item>
        ///         <item>
        ///             <description>Impulse: An event that is created when an impulse (invisible medal) is triggered in the match.</description>
        ///         </item>
        ///         <item>
        ///             <description>Medal: An event that is created when a medal is awarded in the match.</description>
        ///         </item>
        ///         <item>
        ///             <description>PlayerSpawn: An event that is created when a player spawns in the match.</description>
        ///         </item>
        ///         <item>
        ///             <description>RoundStart: An event that is created when a round starts. In regular matches, there is typically one round. However, some modes have multiple rounds.</description>
        ///         </item>
        ///         <item>
        ///             <description>RoundEnd: An event that is created when a round ends. In regular matches, there is typically one round. However, some modes have multiple rounds.</description>
        ///         </item>
        ///         <item>
        ///             <description>WeaponDrop: An event that is created when a player drops a weapon for a new weapon. This occurs when a player picks up a new weapon and drops their current one, when a player dies and drops their weapon(s), or at the end of the match for each player.</description>
        ///         </item>
        ///         <item>
        ///             <description>WeaponPickup: An event that is created when a player picks up a weapon. This can be when a player spawns, or when a player picks up a new weapon.</description>
        ///         </item>
        ///         <item>
        ///             <description>WeaponPickupPad: An event that is created when a player picks up a weapon off a pad. This will not be triggered if the weapon was picked up off the ground after another player who had picked it off a pad.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        [JsonProperty(PropertyName = "EventName")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.EventType EventName { get; set; }

        /// <summary>
        ///     Time passed since the start of the match when the event occurred. This is expressed as an ISO 8601 Duration.
        /// </summary>
        [JsonProperty(PropertyName = "TimeSinceStart")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }

        public bool Equals(GameEvent other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ((Assistants == null && other.Assistants == null) || (Assistants != null && other.Assistants != null && Assistants.OrderBy(a => a.Gamertag).SequenceEqual(other.Assistants.OrderBy(a => a.Gamertag))))
                && DeathDisposition == other.DeathDisposition
                && ImpulseId == other.ImpulseId
                && IsAssassination == other.IsAssassination
                && IsGroundPound == other.IsGroundPound
                && IsHeadshot == other.IsHeadshot
                && IsMelee == other.IsMelee
                && IsShoulderBash == other.IsShoulderBash
                && IsWeapon == other.IsWeapon
                && Equals(Killer, other.Killer)
                && KillerAgent == other.KillerAgent
                && ((KillerWeaponAttachmentIds == null && other.KillerWeaponAttachmentIds == null) || (KillerWeaponAttachmentIds != null && other.KillerWeaponAttachmentIds != null && KillerWeaponAttachmentIds.OrderBy(ka => ka).SequenceEqual(other.KillerWeaponAttachmentIds.OrderBy(ka => ka))))
                && KillerWeaponStockId == other.KillerWeaponStockId
                && Equals(KillerWorldLocation, other.KillerWorldLocation)
                && MedalId == other.MedalId
                && Equals(Player, other.Player)
                && RoundIndex == other.RoundIndex
                && ShotsFired == other.ShotsFired
                && ShotsLanded == other.ShotsLanded
                && TimeWeaponActiveAsPrimary.Equals(other.TimeWeaponActiveAsPrimary)
                && Equals(Victim, other.Victim)
                && VictimAgent == other.VictimAgent
                && ((VictimAttachmentIds == null && other.VictimAttachmentIds == null) || (VictimAttachmentIds != null && other.VictimAttachmentIds != null && VictimAttachmentIds.OrderBy(ka => ka).SequenceEqual(other.VictimAttachmentIds.OrderBy(ka => ka))))
                && VictimStockId == other.VictimStockId
                && Equals(VictimWorldLocation, other.VictimWorldLocation)
                && ((WeaponAttachmentIds == null && other.WeaponAttachmentIds == null) || (WeaponAttachmentIds != null && other.WeaponAttachmentIds != null && WeaponAttachmentIds.OrderBy(ka => ka).SequenceEqual(other.WeaponAttachmentIds.OrderBy(ka => ka))))
                && WeaponStockId == other.WeaponStockId
                && EventName == other.EventName
                && TimeSinceStart.Equals(other.TimeSinceStart);
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

            if (obj.GetType() != typeof (GameEvent))
            {
                return false;
            }

            return Equals((GameEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Assistants?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ DeathDisposition.GetHashCode();
                hashCode = (hashCode*397) ^ ImpulseId.GetHashCode();
                hashCode = (hashCode*397) ^ IsAssassination.GetHashCode();
                hashCode = (hashCode*397) ^ IsGroundPound.GetHashCode();
                hashCode = (hashCode*397) ^ IsHeadshot.GetHashCode();
                hashCode = (hashCode*397) ^ IsMelee.GetHashCode();
                hashCode = (hashCode*397) ^ IsShoulderBash.GetHashCode();
                hashCode = (hashCode*397) ^ IsWeapon.GetHashCode();
                hashCode = (hashCode*397) ^ (Killer?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ KillerAgent.GetHashCode();
                hashCode = (hashCode*397) ^ (KillerWeaponAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ KillerWeaponStockId.GetHashCode();
                hashCode = (hashCode*397) ^ (KillerWorldLocation?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MedalId.GetHashCode();
                hashCode = (hashCode*397) ^ (Player?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ RoundIndex.GetHashCode();
                hashCode = (hashCode*397) ^ ShotsFired.GetHashCode();
                hashCode = (hashCode*397) ^ ShotsLanded.GetHashCode();
                hashCode = (hashCode*397) ^ TimeWeaponActiveAsPrimary.GetHashCode();
                hashCode = (hashCode*397) ^ (Victim?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ VictimAgent.GetHashCode();
                hashCode = (hashCode*397) ^ (VictimAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ VictimStockId.GetHashCode();
                hashCode = (hashCode*397) ^ (VictimWorldLocation?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (WeaponAttachmentIds?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ WeaponStockId.GetHashCode();
                hashCode = (hashCode*397) ^ (int) EventName;
                hashCode = (hashCode*397) ^ TimeSinceStart.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(GameEvent left, GameEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameEvent left, GameEvent right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WorldLocation : IEquatable<WorldLocation>
    {
        /// <summary>
        ///     X Coordinate
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }

        /// <summary>
        ///     Y Coordinate
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }

        /// <summary>
        ///     Z Coordinate
        /// </summary>
        [JsonProperty(PropertyName = "z")]
        public double Z { get; set; }

        public bool Equals(WorldLocation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return X.Equals(other.X)
                && Y.Equals(other.Y)
                && Z.Equals(other.Z);
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

            if (obj.GetType() != typeof (WorldLocation))
            {
                return false;
            }

            return Equals((WorldLocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(WorldLocation left, WorldLocation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WorldLocation left, WorldLocation right)
        {
            return !Equals(left, right);
        }
    }
}