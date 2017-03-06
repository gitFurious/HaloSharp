using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class PlayerJoinedMatch : MatchEvent, IEquatable<PlayerJoinedMatch>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "PlayerType")]
        public Enumeration.HaloWars2.PlayerType PlayerType { get; set; }

        [JsonProperty(PropertyName = "HumanPlayerId")]
        public Identity HumanPlayerId { get; set; }

        [JsonProperty(PropertyName = "ComputerPlayerId")]
        public int? ComputerPlayerId { get; set; }

        [JsonProperty(PropertyName = "ComputerDifficulty")]
        public int? ComputerDifficulty { get; set; }

        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "LeaderId")]
        public int LeaderId { get; set; }

        public bool Equals(PlayerJoinedMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return ComputerDifficulty == other.ComputerDifficulty
                   && ComputerPlayerId == other.ComputerPlayerId
                   && Equals(HumanPlayerId, other.HumanPlayerId)
                   && LeaderId == other.LeaderId
                   && PlayerIndex == other.PlayerIndex
                   && PlayerType == other.PlayerType
                   && TeamId == other.TeamId;
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

            if (obj.GetType() != typeof(PlayerJoinedMatch))
            {
                return false;
            }

            return Equals((PlayerJoinedMatch)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ComputerDifficulty.GetHashCode();
                hashCode = (hashCode * 397) ^ ComputerPlayerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (HumanPlayerId != null ? HumanPlayerId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LeaderId;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ (int)PlayerType;
                hashCode = (hashCode * 397) ^ TeamId;
                return hashCode;
            }
        }

        public static bool operator ==(PlayerJoinedMatch left, PlayerJoinedMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerJoinedMatch left, PlayerJoinedMatch right)
        {
            return !Equals(left, right);
        }
    }
}