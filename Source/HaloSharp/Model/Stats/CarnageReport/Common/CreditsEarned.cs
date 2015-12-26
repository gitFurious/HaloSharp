using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class CreditsEarned : IEquatable<CreditsEarned>
    {
        [JsonProperty(PropertyName = "BoostAmount")]
        public int BoostAmount { get; set; }

        [JsonProperty(PropertyName = "PlayerRankAmount")]
        public int PlayerRankAmount { get; set; }

        [JsonProperty(PropertyName = "Result")]
        public Enumeration.CreditsEarnedResultType Result { get; set; }

        [JsonProperty(PropertyName = "SpartanRankModifier")]
        public double SpartanRankModifier { get; set; }

        [JsonProperty(PropertyName = "TimePlayedAmount")]
        public double TimePlayedAmount { get; set; }

        [JsonProperty(PropertyName = "TotalCreditsEarned")]
        public int TotalCreditsEarned { get; set; }

        public bool Equals(CreditsEarned other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return BoostAmount == other.BoostAmount
                && PlayerRankAmount == other.PlayerRankAmount
                && Result == other.Result
                && SpartanRankModifier.Equals(other.SpartanRankModifier)
                && TimePlayedAmount.Equals(other.TimePlayedAmount)
                && TotalCreditsEarned == other.TotalCreditsEarned;
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

            if (obj.GetType() != typeof (CreditsEarned))
            {
                return false;
            }

            return Equals((CreditsEarned) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BoostAmount;
                hashCode = (hashCode*397) ^ PlayerRankAmount;
                hashCode = (hashCode*397) ^ (int) Result;
                hashCode = (hashCode*397) ^ SpartanRankModifier.GetHashCode();
                hashCode = (hashCode*397) ^ TimePlayedAmount.GetHashCode();
                hashCode = (hashCode*397) ^ TotalCreditsEarned;
                return hashCode;
            }
        }

        public static bool operator ==(CreditsEarned left, CreditsEarned right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreditsEarned left, CreditsEarned right)
        {
            return !Equals(left, right);
        }
    }
}