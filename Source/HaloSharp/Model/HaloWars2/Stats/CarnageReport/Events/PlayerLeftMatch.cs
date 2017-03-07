using System;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class PlayerLeftMatch : MatchEvent, IEquatable<PlayerLeftMatch>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "TimeInMatchMilliseconds")]
        [JsonConverter(typeof(MillisecondConverter))]
        public TimeSpan TimeInMatch { get; set; }

        public bool Equals(PlayerLeftMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return PlayerIndex == other.PlayerIndex
                   && TimeInMatch.Equals(other.TimeInMatch);
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

            if (obj.GetType() != typeof(PlayerLeftMatch))
            {
                return false;
            }

            return Equals((PlayerLeftMatch)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (PlayerIndex * 397) ^ TimeInMatch.GetHashCode();
            }
        }

        public static bool operator ==(PlayerLeftMatch left, PlayerLeftMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerLeftMatch left, PlayerLeftMatch right)
        {
            return !Equals(left, right);
        }
    }
}