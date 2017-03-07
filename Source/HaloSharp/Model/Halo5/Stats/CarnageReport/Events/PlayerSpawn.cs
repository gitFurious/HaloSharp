using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class PlayerSpawn : MatchEvent, IEquatable<PlayerSpawn>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        public bool Equals(PlayerSpawn other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Player, other.Player);
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

            if (obj.GetType() != typeof(PlayerSpawn))
            {
                return false;
            }

            return Equals((PlayerSpawn)obj);
        }

        public override int GetHashCode()
        {
            return (Player != null ? Player.GetHashCode() : 0);
        }

        public static bool operator ==(PlayerSpawn left, PlayerSpawn right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerSpawn left, PlayerSpawn right)
        {
            return !Equals(left, right);
        }
    }
}