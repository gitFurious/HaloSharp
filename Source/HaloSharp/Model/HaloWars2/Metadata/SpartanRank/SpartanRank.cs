using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.SpartanRank
{
    [Serializable]
    public class SpartanRank : IEquatable<SpartanRank>
    {
        [JsonProperty(PropertyName = "StartXP")]
        public int StartXp { get; set; }

        [JsonProperty(PropertyName = "Packs")]
        public List<ContentItemTypeC> Packs { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "RankNumber")]
        public int RankNumber { get; set; }

        public bool Equals(SpartanRank other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(DisplayInfo, other.DisplayInfo)
                && Packs.OrderBy(p => p.Id).SequenceEqual(other.Packs.OrderBy(p => p.Id))
                && RankNumber == other.RankNumber
                && StartXp == other.StartXp;
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

            if (obj.GetType() != typeof(SpartanRank))
            {
                return false;
            }

            return Equals((SpartanRank) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Packs?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ RankNumber;
                hashCode = (hashCode*397) ^ StartXp;
                return hashCode;
            }
        }

        public static bool operator ==(SpartanRank left, SpartanRank right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpartanRank left, SpartanRank right)
        {
            return !Equals(left, right);
        }
    }
}