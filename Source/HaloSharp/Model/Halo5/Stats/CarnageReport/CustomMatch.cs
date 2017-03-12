using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Halo5.Stats.CarnageReport.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport
{
    [Serializable]
    public class CustomMatch : BaseMatch, IEquatable<CustomMatch>
    {
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<CustomMatchPlayerStat> PlayerStats { get; set; }

        [JsonProperty(PropertyName = "TeamStats")]
        public List<TeamStat> TeamStats { get; set; }

        public bool Equals(CustomMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && PlayerStats.OrderBy(ps => ps.Player.Gamertag).SequenceEqual(other.PlayerStats.OrderBy(ps => ps.Player.Gamertag))
                && TeamStats.OrderBy(ts => ts.TeamId).SequenceEqual(other.TeamStats.OrderBy(ts => ts.TeamId));
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

            if (obj.GetType() != typeof (CustomMatch))
            {
                return false;
            }

            return Equals((CustomMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (PlayerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TeamStats?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CustomMatch left, CustomMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomMatch left, CustomMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CustomMatchPlayerStat : BasePlayerStat, IEquatable<CustomMatchPlayerStat>
    {
        [JsonProperty(PropertyName = "KilledByOpponentDetails")]
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }

        [JsonProperty(PropertyName = "KilledOpponentDetails")]
        public List<OpponentDetails> KilledOpponentDetails { get; set; }

        public bool Equals(CustomMatchPlayerStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && KilledByOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(od => od.GamerTag))
                && KilledOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(od => od.GamerTag));
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

            if (obj.GetType() != typeof (CustomMatchPlayerStat))
            {
                return false;
            }

            return Equals((CustomMatchPlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (KilledByOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledOpponentDetails?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CustomMatchPlayerStat left, CustomMatchPlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomMatchPlayerStat left, CustomMatchPlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}