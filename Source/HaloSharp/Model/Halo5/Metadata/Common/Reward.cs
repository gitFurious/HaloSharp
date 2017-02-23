using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Metadata.Common
{
    [Serializable]
    public class Reward : IEquatable<Reward>
    {
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this reward.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The set of requisition packs (if any) that will be awarded.
        /// </summary>
        [JsonProperty(PropertyName = "requisitionPacks")]
        public List<RequisitionPack> RequisitionPacks { get; set; }

        /// <summary>
        /// The amount of XP that will be awarded.
        /// </summary>
        [JsonProperty(PropertyName = "xp")]
        public int Xp { get; set; }

        public bool Equals(Reward other)
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
                   && Id.Equals(other.Id)
                   && RequisitionPacks.OrderBy(rp => rp.Id).SequenceEqual(other.RequisitionPacks.OrderBy(rp => rp.Id))
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

            if (obj.GetType() != typeof (Reward))
            {
                return false;
            }

            return Equals((Reward) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (RequisitionPacks?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Xp;
                return hashCode;
            }
        }

        public static bool operator ==(Reward left, Reward right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Reward left, Reward right)
        {
            return !Equals(left, right);
        }
    }
}