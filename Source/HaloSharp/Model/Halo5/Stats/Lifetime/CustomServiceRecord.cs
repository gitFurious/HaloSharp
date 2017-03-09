﻿using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Halo5.Stats.Common;
using HaloSharp.Model.Halo5.Stats.Lifetime.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime
{
    [Serializable]
    public class CustomServiceRecord : BaseServiceRecord, IEquatable<CustomServiceRecord>
    {
        [JsonProperty(PropertyName = "Results")]
        public List<CustomServiceRecordResult> Results { get; set; }

        public bool Equals(CustomServiceRecord other)
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
                && Results.OrderBy(r => r.Id).SequenceEqual(other.Results.OrderBy(r => r.Id));
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

            if (obj.GetType() != typeof (CustomServiceRecord))
            {
                return false;
            }

            return Equals((CustomServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Results?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CustomServiceRecord left, CustomServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomServiceRecord left, CustomServiceRecord right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CustomServiceRecordResult : BaseServiceRecordResult, IEquatable<CustomServiceRecordResult>
    {
        [JsonProperty(PropertyName = "Result")]
        public CustomResult Result { get; set; }

        public bool Equals(CustomServiceRecordResult other)
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
                && Equals(Result, other.Result);
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

            if (obj.GetType() != typeof (CustomServiceRecordResult))
            {
                return false;
            }

            return Equals((CustomServiceRecordResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Result?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CustomServiceRecordResult left, CustomServiceRecordResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomServiceRecordResult left, CustomServiceRecordResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CustomResult : BaseResult, IEquatable<CustomResult>
    {
        [JsonProperty(PropertyName = "CustomStats")]
        public CustomStats CustomStats { get; set; }

        public bool Equals(CustomResult other)
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
                && Equals(CustomStats, other.CustomStats);
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

            if (obj.GetType() != typeof (CustomResult))
            {
                return false;
            }

            return Equals((CustomResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (CustomStats?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(CustomResult left, CustomResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomResult left, CustomResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CustomStats : BaseStat, IEquatable<CustomStats>
    {
        [JsonProperty(PropertyName = "CustomGameBaseVariantStats")]
        public List<GameBaseVariantStat> CustomGameBaseVariantStats { get; set; }

        [JsonProperty(PropertyName = "TopGameBaseVariants")]
        public List<TopGameBaseVariant> TopGameBaseVariants { get; set; }

        public bool Equals(CustomStats other)
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
                && CustomGameBaseVariantStats.OrderBy(cgbvs => cgbvs.GameBaseVariantId).SequenceEqual(other.CustomGameBaseVariantStats.OrderBy(cgbvs => cgbvs.GameBaseVariantId))
                && TopGameBaseVariants.OrderBy(tgbv => tgbv.GameBaseVariantId).SequenceEqual(other.TopGameBaseVariants.OrderBy(tgbv => tgbv.GameBaseVariantId));
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

            if (obj.GetType() != typeof (CustomStats))
            {
                return false;
            }

            return Equals((CustomStats) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CustomGameBaseVariantStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TopGameBaseVariants?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(CustomStats left, CustomStats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomStats left, CustomStats right)
        {
            return !Equals(left, right);
        }
    }
}