using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class RoundEnd : MatchEvent, IEquatable<RoundEnd>
    {
        [JsonProperty(PropertyName = "RoundIndex")]
        public int RoundIndex { get; set; }

        public bool Equals(RoundEnd other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return RoundIndex == other.RoundIndex;
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

            if (obj.GetType() != typeof(RoundEnd))
            {
                return false;
            }

            return Equals((RoundEnd)obj);
        }

        public override int GetHashCode()
        {
            return RoundIndex;
        }

        public static bool operator ==(RoundEnd left, RoundEnd right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundEnd left, RoundEnd right)
        {
            return !Equals(left, right);
        }
    }
}