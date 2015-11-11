using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;
using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BasePlayerStat : BaseStat, IEquatable<BasePlayerStat>
    {
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan AvgLifeTimeOfPlayer { get; set; }

        // ReSharper disable once InconsistentNaming
        public bool DNF { get; set; }

        public FlexibleStats FlexibleStats { get; set; }
        public Identity Player { get; set; }
        public int Rank { get; set; }
        public int TeamId { get; set; }

        // Internal use only.
        //public object PreMatchRatings { get; set; } //This will always be null.
        //public object PostMatchRatings { get; set; } //This will always be null.

        public bool Equals(BasePlayerStat other)
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
                && AvgLifeTimeOfPlayer.Equals(other.AvgLifeTimeOfPlayer)
                && DNF == other.DNF
                && Equals(FlexibleStats, other.FlexibleStats)
                && Equals(Player, other.Player)
                && Rank == other.Rank
                && TeamId == other.TeamId;
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

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((BasePlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ AvgLifeTimeOfPlayer.GetHashCode();
                hashCode = (hashCode*397) ^ DNF.GetHashCode();
                hashCode = (hashCode*397) ^ (FlexibleStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Player?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Rank;
                hashCode = (hashCode*397) ^ TeamId;
                return hashCode;
            }
        }

        public static bool operator ==(BasePlayerStat left, BasePlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BasePlayerStat left, BasePlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}