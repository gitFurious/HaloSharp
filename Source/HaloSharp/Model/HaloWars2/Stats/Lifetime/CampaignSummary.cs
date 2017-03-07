using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Lifetime
{
    [Serializable]
    public class CampaignSummary : IEquatable<CampaignSummary>
    {
        [JsonProperty(PropertyName = "CampaignXP")]
        public int CampaignXp { get; set; }

        [JsonProperty(PropertyName = "Levels")]
        public Dictionary<int, CampaignLevel> Levels { get; set; }

        [JsonProperty(PropertyName = "LogsUnlocked")]
        public List<int> LogsUnlocked { get; set; }

        public bool Equals(CampaignSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CampaignXp == other.CampaignXp
                && Levels.OrderBy(l => l.Key).SequenceEqual(other.Levels.OrderBy(l => l.Key))
                && LogsUnlocked.OrderBy(l => l).SequenceEqual(other.LogsUnlocked.OrderBy(l => l));
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

            if (obj.GetType() != typeof(CampaignSummary))
            {
                return false;
            }

            return Equals((CampaignSummary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CampaignXp;
                hashCode = (hashCode*397) ^ (Levels?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (LogsUnlocked?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CampaignSummary left, CampaignSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignSummary left, CampaignSummary right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignLevel : IEquatable<CampaignLevel>
    {
        [JsonProperty(PropertyName = "SkullsUnlocked")]
        public List<int> SkullsUnlocked { get; set; }

        [JsonProperty(PropertyName = "TotalSoloPlayTime")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalSoloPlayTime { get; set; }

        [JsonProperty(PropertyName = "TotalCooperativePlayTime")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalCooperativePlayTime { get; set; }

        [JsonProperty(PropertyName = "SoloCompletion")]
        public Dictionary<int, CampaignLevelCompletion> SoloCompletion { get; set; }

        [JsonProperty(PropertyName = "CooperativeCompletion")]
        public Dictionary<int, CampaignLevelCompletion> CooperativeCompletion { get; set; }

        [JsonProperty(PropertyName = "FirstCompletionDate")]
        public ISO8601 FirstCompletionDate { get; set; }

        public bool Equals(CampaignLevel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CooperativeCompletion.OrderBy(sc => sc.Key).SequenceEqual(other.CooperativeCompletion.OrderBy(sc => sc.Key))
                && Equals(FirstCompletionDate, other.FirstCompletionDate)
                && SkullsUnlocked.OrderBy(s => s).SequenceEqual(other.SkullsUnlocked.OrderBy(s => s))
                && SoloCompletion.OrderBy(sc => sc.Key).SequenceEqual(other.SoloCompletion.OrderBy(sc => sc.Key))
                && TotalCooperativePlayTime.Equals(other.TotalCooperativePlayTime)
                && TotalSoloPlayTime.Equals(other.TotalSoloPlayTime);
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

            if (obj.GetType() != typeof(CampaignLevel))
            {
                return false;
            }

            return Equals((CampaignLevel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CooperativeCompletion?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (FirstCompletionDate != null ? FirstCompletionDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SkullsUnlocked?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SoloCompletion?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalCooperativePlayTime.GetHashCode();
                hashCode = (hashCode*397) ^ TotalSoloPlayTime.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CampaignLevel left, CampaignLevel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignLevel left, CampaignLevel right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignLevelCompletion : IEquatable<CampaignLevelCompletion>
    {
        [JsonProperty(PropertyName = "BestCompletionTime")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan BestCompletionTime { get; set; }

        [JsonProperty(PropertyName = "BestScore")]
        public int BestScore { get; set; }

        [JsonProperty(PropertyName = "CriticalObjectivesCompleted")]
        public List<int> CriticalObjectivesCompleted { get; set; }

        [JsonProperty(PropertyName = "BonusObjectivesCompleted")]
        public List<int> BonusObjectivesCompleted { get; set; }

        [JsonProperty(PropertyName = "OptionalObjectivesCompleted")]
        public List<int> OptionalObjectivesCompleted { get; set; }

        public bool Equals(CampaignLevelCompletion other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return BestCompletionTime.Equals(other.BestCompletionTime)
                && BestScore == other.BestScore
                && BonusObjectivesCompleted.OrderBy(boc => boc).SequenceEqual(other.BonusObjectivesCompleted.OrderBy(boc => boc))
                && CriticalObjectivesCompleted.OrderBy(coc => coc).SequenceEqual(other.CriticalObjectivesCompleted.OrderBy(coc => coc))
                && OptionalObjectivesCompleted.OrderBy(ooc => ooc).SequenceEqual(other.OptionalObjectivesCompleted.OrderBy(ooc => ooc));
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

            if (obj.GetType() != typeof(CampaignLevelCompletion))
            {
                return false;
            }

            return Equals((CampaignLevelCompletion) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BestCompletionTime.GetHashCode();
                hashCode = (hashCode*397) ^ BestScore;
                hashCode = (hashCode*397) ^ (BonusObjectivesCompleted?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (CriticalObjectivesCompleted?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (OptionalObjectivesCompleted?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CampaignLevelCompletion left, CampaignLevelCompletion right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignLevelCompletion left, CampaignLevelCompletion right)
        {
            return !Equals(left, right);
        }
    }
}
