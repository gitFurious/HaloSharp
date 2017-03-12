using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class Medal : MatchEvent, IEquatable<Medal>
    {
        [JsonProperty(PropertyName = "MedalId")]
        public uint MedalId { get; set; }

        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        public bool Equals(Medal other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return MedalId == other.MedalId
                   && Equals(Player, other.Player);
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

            if (obj.GetType() != typeof(Medal))
            {
                return false;
            }

            return Equals((Medal)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)MedalId * 397) ^ (Player != null ? Player.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Medal left, Medal right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Medal left, Medal right)
        {
            return !Equals(left, right);
        }
    }
}