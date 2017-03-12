using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.DisplayInfo
{
    [Serializable]
    public class BatchLocalization : IEquatable<BatchLocalization>
    {
        [JsonProperty(PropertyName = "IsLocked")]
        public bool IsLocked { get; set; }

        public bool Equals(BatchLocalization other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return IsLocked == other.IsLocked;
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

            if (obj.GetType() != typeof(BatchLocalization))
            {
                return false;
            }

            return Equals((BatchLocalization) obj);
        }

        public override int GetHashCode()
        {
            return IsLocked.GetHashCode();
        }

        public static bool operator ==(BatchLocalization left, BatchLocalization right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BatchLocalization left, BatchLocalization right)
        {
            return !Equals(left, right);
        }
    }
}