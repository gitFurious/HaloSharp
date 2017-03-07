using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class Death : MatchEvent, IEquatable<Death>
    {
        [JsonProperty(PropertyName = "VictimPlayerIndex")]
        public int VictimPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "VictimObjectTypeId")]
        public string VictimObjectTypeId { get; set; }

        [JsonProperty(PropertyName = "VictimInstanceId")]
        public int VictimInstanceId { get; set; }

        [JsonProperty(PropertyName = "VictimLocation")]
        public Location VictimLocation { get; set; }

        [JsonProperty(PropertyName = "IsSuicide")]
        public bool IsSuicide { get; set; }

        [JsonProperty(PropertyName = "Participants")]
        public Dictionary<int, Participant> Participants { get; set; }

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

            return base.Equals(other)
                && IsSuicide == other.IsSuicide
                && Equals(Participants, other.Participants)
                && VictimInstanceId == other.VictimInstanceId
                && Equals(VictimLocation, other.VictimLocation)
                && string.Equals(VictimObjectTypeId, other.VictimObjectTypeId)
                && VictimPlayerIndex == other.VictimPlayerIndex;
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

            return Equals((Death) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ IsSuicide.GetHashCode();
                hashCode = (hashCode*397) ^ (Participants?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ VictimInstanceId;
                hashCode = (hashCode*397) ^ (VictimLocation != null ? VictimLocation.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (VictimObjectTypeId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ VictimPlayerIndex;
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

    [Serializable]
    public class Participant : IEquatable<Participant>
    {
        [JsonProperty(PropertyName = "ObjectParticipants")]
        public Dictionary<string, ObjectParticipant> ObjectParticipants { get; set; }

        public bool Equals(Participant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return ObjectParticipants.OrderBy(o => o.Key).SequenceEqual(other.ObjectParticipants.OrderBy(o => o.Key));
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

            if (obj.GetType() != typeof(Participant))
            {
                return false;
            }

            return Equals((Participant)obj);
        }

        public override int GetHashCode()
        {
            return ObjectParticipants?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Participant left, Participant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Participant left, Participant right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ObjectParticipant : IEquatable<ObjectParticipant>
    {
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "CombatStats")]
        public Dictionary<Enumeration.HaloWars2.DamageType, CombatStat> CombatStats { get; set; }

        public bool Equals(ObjectParticipant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CombatStats.OrderBy(co => co.Key).SequenceEqual(other.CombatStats.OrderBy(co => co.Key))
                && Count == other.Count;
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

            if (obj.GetType() != typeof(ObjectParticipant))
            {
                return false;
            }

            return Equals((ObjectParticipant)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((CombatStats?.GetHashCode() ?? 0) * 397) ^ Count;
            }
        }

        public static bool operator ==(ObjectParticipant left, ObjectParticipant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObjectParticipant left, ObjectParticipant right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CombatStat : IEquatable<CombatStat>
    {
        [JsonProperty(PropertyName = "AttacksLanded")]
        public int AttacksLanded { get; set; }

        public bool Equals(CombatStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return AttacksLanded == other.AttacksLanded;
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

            if (obj.GetType() != typeof(CombatStat))
            {
                return false;
            }

            return Equals((CombatStat)obj);
        }

        public override int GetHashCode()
        {
            return AttacksLanded;
        }

        public static bool operator ==(CombatStat left, CombatStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CombatStat left, CombatStat right)
        {
            return !Equals(left, right);
        }
    }
}