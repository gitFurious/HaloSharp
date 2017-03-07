using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class Impulse : MatchEvent, IEquatable<Impulse>
    {
        [JsonProperty(PropertyName = "ImpulseId")]
        public uint ImpulseId { get; set; }

        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        public bool Equals(Impulse other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ImpulseId == other.ImpulseId
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

            if (obj.GetType() != typeof(Impulse))
            {
                return false;
            }

            return Equals((Impulse)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)ImpulseId * 397) ^ (Player != null ? Player.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Impulse left, Impulse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Impulse left, Impulse right)
        {
            return !Equals(left, right);
        }
    }
}