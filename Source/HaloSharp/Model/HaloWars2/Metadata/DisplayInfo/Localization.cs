using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.DisplayInfo
{
    [Serializable]
    public class Localization : IEquatable<Localization>
    {
        [JsonProperty(PropertyName = "Culture")]
        public string Culture { get; set; }

        [JsonProperty(PropertyName = "MasterContentItemId")]
        public string MasterContentItemId { get; set; }

        public bool Equals(Localization other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Culture, other.Culture) 
                && string.Equals(MasterContentItemId, other.MasterContentItemId);
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

            if (obj.GetType() != typeof(Localization))
            {
                return false;
            }

            return Equals((Localization) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Culture?.GetHashCode() ?? 0)*397) ^ (MasterContentItemId?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(Localization left, Localization right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Localization left, Localization right)
        {
            return !Equals(left, right);
        }
    }
}