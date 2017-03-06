using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class CardPlayed : MatchEvent, IEquatable<CardPlayed>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "CardId")]
        public Guid CardId { get; set; }

        [JsonProperty(PropertyName = "InstanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "ManaCost")]
        public int ManaCost { get; set; }

        [JsonProperty(PropertyName = "TargetLocation")]
        public Location TargetLocation { get; set; }

        [JsonProperty(PropertyName = "SpawnAtBase")]
        public bool SpawnAtBase { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(CardPlayed other)
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
                && CardId.Equals(other.CardId)
                && InstanceId == other.InstanceId
                && ManaCost == other.ManaCost
                && PlayerIndex == other.PlayerIndex
                && ProvidedByScenario == other.ProvidedByScenario
                && SpawnAtBase == other.SpawnAtBase
                && Equals(TargetLocation, other.TargetLocation);
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

            if (obj.GetType() != typeof(CardPlayed))
            {
                return false;
            }

            return Equals((CardPlayed) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ CardId.GetHashCode();
                hashCode = (hashCode*397) ^ InstanceId;
                hashCode = (hashCode*397) ^ ManaCost;
                hashCode = (hashCode*397) ^ PlayerIndex;
                hashCode = (hashCode*397) ^ ProvidedByScenario.GetHashCode();
                hashCode = (hashCode*397) ^ SpawnAtBase.GetHashCode();
                hashCode = (hashCode*397) ^ (TargetLocation != null ? TargetLocation.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CardPlayed left, CardPlayed right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardPlayed left, CardPlayed right)
        {
            return !Equals(left, right);
        }
    }
}