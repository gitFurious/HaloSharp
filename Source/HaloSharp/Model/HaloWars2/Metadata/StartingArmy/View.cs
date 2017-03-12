using System;
using HaloSharp.Model.HaloWars2.Metadata.DisplayInfo;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.StartingArmy
{
    [Serializable]
    public class View : Metadata.View, IEquatable<View>
    {
        [JsonProperty(PropertyName = "HW2StartingArmy")]
        public StartingArmy StartingArmy { get; set; }

        [JsonProperty(PropertyName = "BatchLocalization")]
        public BatchLocalization BatchLocalization { get; set; }

        [JsonProperty(PropertyName = "Localization")]
        public Localization Localization { get; set; }

        public bool Equals(View other)
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
                && Equals(BatchLocalization, other.BatchLocalization)
                && Equals(Localization, other.Localization)
                && Equals(StartingArmy, other.StartingArmy);
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

            if (obj.GetType() != typeof(View))
            {
                return false;
            }

            return Equals((View) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (BatchLocalization != null ? BatchLocalization.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Localization != null ? Localization.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (StartingArmy?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(View left, View right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(View left, View right)
        {
            return !Equals(left, right);
        }
    }
}