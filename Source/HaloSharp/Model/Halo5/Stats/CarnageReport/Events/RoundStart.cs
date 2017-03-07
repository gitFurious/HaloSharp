using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class RoundStart : MatchEvent, IEquatable<RoundStart>
    {
        [JsonProperty(PropertyName = "RoundIndex")]
        public int RoundIndex { get; set; }

        public bool Equals(RoundStart other)
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

            if (obj.GetType() != typeof(RoundStart))
            {
                return false;
            }

            return Equals((RoundStart)obj);
        }

        public override int GetHashCode()
        {
            return RoundIndex;
        }

        public static bool operator ==(RoundStart left, RoundStart right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundStart left, RoundStart right)
        {
            return !Equals(left, right);
        }
    }
}