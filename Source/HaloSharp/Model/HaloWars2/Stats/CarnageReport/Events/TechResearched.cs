using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class TechResearched : MatchEvent, IEquatable<TechResearched>
    {
        [JsonProperty(PropertyName = "PlayerIndex")]
        public int PlayerIndex { get; set; }

        [JsonProperty(PropertyName = "TechId")]
        public string TechId { get; set; }

        [JsonProperty(PropertyName = "ResearcherInstanceId")]
        public int ResearcherInstanceId { get; set; }

        [JsonProperty(PropertyName = "SupplyCost")]
        public int SupplyCost { get; set; }

        [JsonProperty(PropertyName = "EnergyCost")]
        public int EnergyCost { get; set; }

        [JsonProperty(PropertyName = "ProvidedByScenario")]
        public bool ProvidedByScenario { get; set; }

        public bool Equals(TechResearched other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return EnergyCost == other.EnergyCost
                   && PlayerIndex == other.PlayerIndex
                   && ProvidedByScenario == other.ProvidedByScenario
                   && ResearcherInstanceId == other.ResearcherInstanceId
                   && SupplyCost == other.SupplyCost
                   && string.Equals(TechId, other.TechId);
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

            if (obj.GetType() != typeof(TechResearched))
            {
                return false;
            }

            return Equals((TechResearched)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EnergyCost;
                hashCode = (hashCode * 397) ^ PlayerIndex;
                hashCode = (hashCode * 397) ^ ProvidedByScenario.GetHashCode();
                hashCode = (hashCode * 397) ^ ResearcherInstanceId;
                hashCode = (hashCode * 397) ^ SupplyCost;
                hashCode = (hashCode * 397) ^ (TechId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(TechResearched left, TechResearched right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TechResearched left, TechResearched right)
        {
            return !Equals(left, right);
        }
    }
}