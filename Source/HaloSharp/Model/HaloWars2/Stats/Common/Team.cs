using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Common
{
    [Serializable]
    public class Team : IEquatable<Team>
    {
        [JsonProperty(PropertyName = "TeamSize")]
        public int TeamSize { get; set; }

        public bool Equals(Team other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return TeamSize == other.TeamSize;
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

            if (obj.GetType() != typeof(Team))
			{
				return false;
			}

            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            return TeamSize;
        }

        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }
    }
}