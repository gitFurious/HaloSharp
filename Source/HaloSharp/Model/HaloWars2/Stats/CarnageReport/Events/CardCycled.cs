using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class CardCycled : MatchEvent, IEquatable<CardCycled>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "ManaCost")]
        public int ManaCost { get; set; }

        public bool Equals(CardCycled other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return ManaCost == other.ManaCost
                   && PlayerIndex == other.PlayerIndex;
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

            if (obj.GetType() != typeof(CardCycled))
            {
                return false;
            }

            return Equals((CardCycled)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ManaCost * 397) ^ PlayerIndex;
            }
        }

        public static bool operator ==(CardCycled left, CardCycled right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardCycled left, CardCycled right)
        {
            return !Equals(left, right);
        }
    }
}