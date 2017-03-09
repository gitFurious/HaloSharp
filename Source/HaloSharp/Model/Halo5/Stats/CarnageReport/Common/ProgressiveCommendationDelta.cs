using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Common
{
    [Serializable]
    public class ProgressiveCommendationDelta : IEquatable<ProgressiveCommendationDelta>
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "PreviousProgress")]
        public int PreviousProgress { get; set; }

        [JsonProperty(PropertyName = "Progress")]
        public int Progress { get; set; }

        public bool Equals(ProgressiveCommendationDelta other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id)
                && PreviousProgress == other.PreviousProgress
                && Progress == other.Progress;
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

            if (obj.GetType() != typeof (ProgressiveCommendationDelta))
            {
                return false;
            }

            return Equals((ProgressiveCommendationDelta) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ PreviousProgress;
                hashCode = (hashCode*397) ^ Progress;
                return hashCode;
            }
        }

        public static bool operator ==(ProgressiveCommendationDelta left, ProgressiveCommendationDelta right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProgressiveCommendationDelta left, ProgressiveCommendationDelta right)
        {
            return !Equals(left, right);
        }
    }
}