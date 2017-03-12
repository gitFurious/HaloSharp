using System;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime.Common
{
    [Serializable]
    public class BaseResult : IEquatable<BaseResult>
    {
        [JsonProperty(PropertyName = "PlayerId")]
        public Identity PlayerId { get; set; }

        [JsonProperty(PropertyName = "SpartanRank")]
        public int SpartanRank { get; set; }

        [JsonProperty(PropertyName = "Xp")]
        public int Xp { get; set; }

        public bool Equals(BaseResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(PlayerId, other.PlayerId)
                && SpartanRank == other.SpartanRank
                && Xp == other.Xp;
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

            if (obj.GetType() != typeof (BaseResult))
            {
                return false;
            }

            return Equals((BaseResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = PlayerId?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ SpartanRank;
                hashCode = (hashCode*397) ^ Xp;
                return hashCode;
            }
        }

        public static bool operator ==(BaseResult left, BaseResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseResult left, BaseResult right)
        {
            return !Equals(left, right);
        }
    }
}