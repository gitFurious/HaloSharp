using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class PlayerEliminated : MatchEvent, IEquatable<PlayerEliminated>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        public bool Equals(PlayerEliminated other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return PlayerIndex == other.PlayerIndex;
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

            if (obj.GetType() != typeof(PlayerEliminated))
            {
                return false;
            }

            return Equals((PlayerEliminated)obj);
        }

        public override int GetHashCode()
        {
            return PlayerIndex;
        }

        public static bool operator ==(PlayerEliminated left, PlayerEliminated right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerEliminated left, PlayerEliminated right)
        {
            return !Equals(left, right);
        }
    }
}