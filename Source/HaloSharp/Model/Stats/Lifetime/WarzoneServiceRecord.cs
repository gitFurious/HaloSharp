using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.Lifetime
{
    [Serializable]
    public class WarzoneServiceRecord : BaseServiceRecord, IEquatable<WarzoneServiceRecord>
    {
        public List<WarzoneServiceRecordResult> Results { get; set; }

        public bool Equals(WarzoneServiceRecord other)
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
                && Results.OrderBy(r => r.Id).SequenceEqual(other.Results.OrderBy(r => r.Id));
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

            if (obj.GetType() != typeof (WarzoneServiceRecord))
            {
                return false;
            }

            return Equals((WarzoneServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Results != null ? Results.GetHashCode() : 0);
            }
        }

        public static bool operator ==(WarzoneServiceRecord left, WarzoneServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneServiceRecord left, WarzoneServiceRecord right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WarzoneServiceRecordResult : BaseServiceRecordResult, IEquatable<WarzoneServiceRecordResult>
    {
        public WarzoneResult Result { get; set; }

        public bool Equals(WarzoneServiceRecordResult other)
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
                && Equals(Result, other.Result);
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

            if (obj.GetType() != typeof (WarzoneServiceRecordResult))
            {
                return false;
            }

            return Equals((WarzoneServiceRecordResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Result?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(WarzoneServiceRecordResult left, WarzoneServiceRecordResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneServiceRecordResult left, WarzoneServiceRecordResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WarzoneResult : BaseResult, IEquatable<WarzoneResult>
    {
        public WarzoneStat WarzoneStat { get; set; }

        public bool Equals(WarzoneResult other)
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
                && Equals(WarzoneStat, other.WarzoneStat);
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

            if (obj.GetType() != typeof (WarzoneResult))
            {
                return false;
            }

            return Equals((WarzoneResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (WarzoneStat?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(WarzoneResult left, WarzoneResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneResult left, WarzoneResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WarzoneStat : BaseStat, IEquatable<WarzoneStat>
    {
        public List<ScenarioStat> ScenarioStats { get; set; }
        public int TotalPiesEarned { get; set; }

        public bool Equals(WarzoneStat other)
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
                && ScenarioStats.OrderBy(ss => ss.GameBaseVariantId).ThenBy(ss => ss.MapId).SequenceEqual(other.ScenarioStats.OrderBy(ss => ss.GameBaseVariantId).ThenBy(ss => ss.MapId))
                && TotalPiesEarned == other.TotalPiesEarned;
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

            if (obj.GetType() != typeof (WarzoneStat))
            {
                return false;
            }

            return Equals((WarzoneStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (ScenarioStats != null ? ScenarioStats.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TotalPiesEarned;
                return hashCode;
            }
        }

        public static bool operator ==(WarzoneStat left, WarzoneStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneStat left, WarzoneStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ScenarioStat : BaseStat, IEquatable<ScenarioStat>
    {
        public FlexibleStats FlexibleStats { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public Guid MapId { get; set; }
        public int TotalPiesEarned { get; set; }

        public bool Equals(ScenarioStat other)
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
                && Equals(FlexibleStats, other.FlexibleStats)
                && GameBaseVariantId.Equals(other.GameBaseVariantId)
                && MapId.Equals(other.MapId)
                && TotalPiesEarned == other.TotalPiesEarned;
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

            if (obj.GetType() != typeof (ScenarioStat))
            {
                return false;
            }

            return Equals((ScenarioStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (FlexibleStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ TotalPiesEarned;
                return hashCode;
            }
        }

        public static bool operator ==(ScenarioStat left, ScenarioStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScenarioStat left, ScenarioStat right)
        {
            return !Equals(left, right);
        }
    }
}