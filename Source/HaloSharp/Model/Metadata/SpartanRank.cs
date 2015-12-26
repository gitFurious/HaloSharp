using System;
using HaloSharp.Model.Metadata.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class SpartanRank : IEquatable<SpartanRank>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        [JsonProperty(PropertyName = "startXp")]
        public int StartXp { get; set; }

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
            return ContentId.Equals(other.ContentId)
                && Id == other.Id
                && Equals(Reward, other.Reward)
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

            if (obj.GetType() != typeof (SpartanRank))
            {
                return false;
            }

            return Equals((SpartanRank) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id;
                hashCode = (hashCode*397) ^ (Reward?.GetHashCode() ?? 0);
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