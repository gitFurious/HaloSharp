using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class BoostInfo : IEquatable<BoostInfo>
    {
        /// <summary>
        /// TODO:
        /// </summary>
        [JsonProperty(PropertyName = "CardConsumed")]
        public bool CardConsumed { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        [JsonProperty(PropertyName = "DefinitionId")]
        public Guid DefinitionId { get; set; }

        public bool Equals(BoostInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CardConsumed == other.CardConsumed 
                && DefinitionId.Equals(other.DefinitionId);
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

            if (obj.GetType() != typeof(BoostInfo))
            {
                return false;
            }

            return Equals((BoostInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CardConsumed.GetHashCode() * 397) ^ DefinitionId.GetHashCode();
            }
        }

        public static bool operator ==(BoostInfo left, BoostInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BoostInfo left, BoostInfo right)
        {
            return !Equals(left, right);
        }
    }
}