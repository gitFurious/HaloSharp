using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.Lifetime
{
    [Serializable]
    public class CampaignServiceRecord : BaseServiceRecord, IEquatable<CampaignServiceRecord>
    {
        public List<CampaignServiceRecordResult> Results { get; set; }

        public bool Equals(CampaignServiceRecord other)
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

            if (obj.GetType() != typeof (CampaignServiceRecord))
            {
                return false;
            }

            return Equals((CampaignServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Results?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CampaignServiceRecord left, CampaignServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignServiceRecord left, CampaignServiceRecord right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignServiceRecordResult : BaseServiceRecordResult, IEquatable<CampaignServiceRecordResult>
    {
        public CampaignResult Result { get; set; }

        public bool Equals(CampaignServiceRecordResult other)
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

            if (obj.GetType() != typeof (CampaignServiceRecordResult))
            {
                return false;
            }

            return Equals((CampaignServiceRecordResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Result?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CampaignServiceRecordResult left, CampaignServiceRecordResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignServiceRecordResult left, CampaignServiceRecordResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignResult : BaseResult, IEquatable<CampaignResult>
    {
        public CampaignStat CampaignStat { get; set; }

        public bool Equals(CampaignResult other)
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
                && Equals(CampaignStat, other.CampaignStat);
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

            if (obj.GetType() != typeof (CampaignResult))
            {
                return false;
            }

            return Equals((CampaignResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (CampaignStat?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CampaignResult left, CampaignResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignResult left, CampaignResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignStat : BaseStat, IEquatable<CampaignStat>
    {
        public List<CampaignMissionStat> CampaignMissionStats { get; set; }

        public bool Equals(CampaignStat other)
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
                && CampaignMissionStats.OrderBy(cms => cms.MissionId).SequenceEqual(other.CampaignMissionStats.OrderBy(cms => cms.MissionId));
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

            if (obj.GetType() != typeof (CampaignStat))
            {
                return false;
            }

            return Equals((CampaignStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (CampaignMissionStats?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CampaignStat left, CampaignStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignStat left, CampaignStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignMissionStat : BaseStat, IEquatable<CampaignMissionStat>
    {
        public Dictionary<Enumeration.Difficulty, Stats> CoopStats { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public Guid MissionId { get; set; }
        public Dictionary<Enumeration.Difficulty, Stats> SoloStats { get; set; }

        public bool Equals(CampaignMissionStat other)
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
                && CoopStats.OrderBy(cs => cs.Key).SequenceEqual(other.CoopStats.OrderBy(cs => cs.Key))
                && Equals(FlexibleStats, other.FlexibleStats)
                && MissionId.Equals(other.MissionId)
                && SoloStats.OrderBy(ss => ss.Key).SequenceEqual(other.SoloStats.OrderBy(ss => ss.Key));
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

            if (obj.GetType() != typeof (CampaignMissionStat))
            {
                return false;
            }

            return Equals((CampaignMissionStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CoopStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (FlexibleStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MissionId.GetHashCode();
                hashCode = (hashCode*397) ^ (SoloStats?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMissionStat left, CampaignMissionStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMissionStat left, CampaignMissionStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Stats : IEquatable<Stats>
    {
        public bool AllSkullsOn { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan FastestCompletionTime { get; set; }

        public int HighestScore { get; set; }
        public List<int> Skulls { get; set; }
        public int TotalTimesCompleted { get; set; }

        public bool Equals(Stats other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return AllSkullsOn == other.AllSkullsOn
                && FastestCompletionTime.Equals(other.FastestCompletionTime)
                && HighestScore == other.HighestScore
                && Skulls.OrderBy(s => s).SequenceEqual(other.Skulls.OrderBy(s => s))
                && TotalTimesCompleted == other.TotalTimesCompleted;
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

            if (obj.GetType() != typeof (Stats))
            {
                return false;
            }

            return Equals((Stats) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AllSkullsOn.GetHashCode();
                hashCode = (hashCode*397) ^ FastestCompletionTime.GetHashCode();
                hashCode = (hashCode*397) ^ HighestScore;
                hashCode = (hashCode*397) ^ (Skulls?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalTimesCompleted;
                return hashCode;
            }
        }

        public static bool operator ==(Stats left, Stats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stats left, Stats right)
        {
            return !Equals(left, right);
        }
    }
}