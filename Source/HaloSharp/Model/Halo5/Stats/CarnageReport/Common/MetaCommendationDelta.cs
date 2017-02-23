using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Common
{
    [Serializable]
    public class MetaCommendationDelta : IEquatable<MetaCommendationDelta>
    {
        /// <summary>
        /// The commendation ID. Commendations are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The progress the player had made towards the commendation level before the match.
        /// </summary>
        [JsonProperty(PropertyName = "PreviousMetRequirements")]
        public List<Requirement> PreviousMetRequirements { get; set; }

        /// <summary>
        /// The progress the player had made towards the commendation level after the match.
        /// </summary>
        [JsonProperty(PropertyName = "MetRequirements")]
        public List<Requirement> MetRequirements { get; set; }

        public bool Equals(MetaCommendationDelta other)
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
                && PreviousMetRequirements.OrderBy(mcd => mcd.Guid).SequenceEqual(other.PreviousMetRequirements.OrderBy(mcd => mcd.Guid))
                && MetRequirements.OrderBy(mcd => mcd.Guid).SequenceEqual(other.MetRequirements.OrderBy(mcd => mcd.Guid));
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

            if (obj.GetType() != typeof(MetaCommendationDelta))
            {
                return false;
            }

            return Equals((MetaCommendationDelta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (PreviousMetRequirements?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (MetRequirements?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(MetaCommendationDelta left, MetaCommendationDelta right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MetaCommendationDelta left, MetaCommendationDelta right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Requirement : IEquatable<Requirement>
    {
        [JsonConstructor]
        public Requirement(uint data1, ushort data2, ushort data3, ulong data4)
        {
            Data1 = data1;
            Data2 = data2;
            Data3 = data3;
            Data4 = data4;
            Guid = new Guid((int)data1, (short)data2, (short)data3, BitConverter.GetBytes((long)data4));
        }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "Data1")]
        public uint Data1 { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "Data2")]
        public ushort Data2 { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "Data3")]
        public ushort Data3 { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "Data4")]
        public ulong Data4 { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [JsonIgnore]
        public Guid Guid { get; }

        public bool Equals(Requirement other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Data1 == other.Data1
                && Data2 == other.Data2
                && Data3 == other.Data3
                && Data4 == other.Data4
                && Guid.Equals(other.Guid);
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

            if (obj.GetType() != typeof(Requirement))
            {
                return false;
            }

            return Equals((Requirement)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Data1;
                hashCode = (hashCode * 397) ^ Data2.GetHashCode();
                hashCode = (hashCode * 397) ^ Data3.GetHashCode();
                hashCode = (hashCode * 397) ^ Data4.GetHashCode();
                hashCode = (hashCode * 397) ^ Guid.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Requirement left, Requirement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Requirement left, Requirement right)
        {
            return !Equals(left, right);
        }
    }
}
