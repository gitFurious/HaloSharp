using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class LeaderPowerUnlocked : MatchEvent, IEquatable<LeaderPowerUnlocked>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "PowerId")]
        public string PowerId { get; set; }

        [JsonProperty(PropertyName = "CommandPointCost")]
        public int CommandPointCost { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(LeaderPowerUnlocked other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CommandPointCost == other.CommandPointCost
                   && PlayerIndex == other.PlayerIndex
                   && string.Equals(PowerId, other.PowerId)
                   && ProvidedByScenario == other.ProvidedByScenario;
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

            if (obj.GetType() != typeof(LeaderPowerUnlocked))
            {
                return false;
            }

            return Equals((LeaderPowerUnlocked)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommandPointCost;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ (PowerId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ ProvidedByScenario.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LeaderPowerUnlocked left, LeaderPowerUnlocked right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeaderPowerUnlocked left, LeaderPowerUnlocked right)
        {
            return !Equals(left, right);
        }
    }
}