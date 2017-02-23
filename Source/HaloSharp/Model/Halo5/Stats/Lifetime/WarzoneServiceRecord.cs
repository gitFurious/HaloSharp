using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Halo5.Stats.Common;
using HaloSharp.Model.Halo5.Stats.Lifetime.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime
{
    [Serializable]
    public class WarzoneServiceRecord : BaseServiceRecord, IEquatable<WarzoneServiceRecord>
    {
        /// <summary>
        /// Set of responses. One per user queried.
        /// </summary>
        [JsonProperty(PropertyName = "Results")]
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
                return (base.GetHashCode()*397) ^ (Results?.GetHashCode() ?? 0);
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
        /// <summary>
        /// The Service Record result for the player. Only set if ResultCode is Success.
        /// </summary>
        [JsonProperty(PropertyName = "Result")]
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
        /// <summary>
        /// Warzone stats data.
        /// </summary>
        [JsonProperty(PropertyName = "WarzoneStat")]
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
        /// <summary>
        /// List of scenario stats by map and game base variant id.
        /// </summary>
        [JsonProperty(PropertyName = "ScenarioStats")]
        public List<ScenarioStat> ScenarioStats { get; set; }

        /// <summary>
        /// The total number of "pies" (in-game currency) the player has earned.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPiesEarned")]
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
                hashCode = (hashCode*397) ^ (ScenarioStats?.GetHashCode() ?? 0);
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
        /// <summary>
        /// The game base variant specific stats. Flexible stats are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "FlexibleStats")]
        public FlexibleStats FlexibleStats { get; set; }

        /// <summary>
        /// The ID of the game base variant. Game base variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        /// <summary>
        /// The map global ID that this warzone scenario pertains to. Found in metadata.
        /// </summary>
        [JsonProperty(PropertyName = "MapId")]
        public Guid MapId { get; set; }

        /// <summary>
        /// The total number of "pies" (in-game currency) the player has earned in the scenario.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPiesEarned")]
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