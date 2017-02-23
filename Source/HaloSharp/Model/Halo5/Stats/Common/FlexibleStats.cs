using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Common
{
    [Serializable]
    public class FlexibleStats : IEquatable<FlexibleStats>
    {
        /// <summary>
        /// The set of flexible stats that are derived from impulse events.
        /// </summary>
        [JsonProperty(PropertyName = "ImpulseStatCounts")]
        public List<StatCount> ImpulseStatCounts { get; set; }

        /// <summary>
        /// The set of flexible stats that are derived from impulse time lapses.
        /// </summary>
        [JsonProperty(PropertyName = "ImpulseTimelapses")]
        public List<StatTimelapse> ImpulseTimelapses { get; set; }

        /// <summary>
        /// The set of flexible stats that are derived from medal events.
        /// </summary>
        [JsonProperty(PropertyName = "MedalStatCounts")]
        public List<StatCount> MedalStatCounts { get; set; }

        /// <summary>
        /// The set of flexible stats that are derived from medal time lapses.
        /// </summary>
        [JsonProperty(PropertyName = "MedalTimelapses")]
        public List<StatTimelapse> MedalTimelapses { get; set; }

        public bool Equals(FlexibleStats other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ImpulseStatCounts.OrderBy(isc => isc.Id).SequenceEqual(other.ImpulseStatCounts.OrderBy(isc => isc.Id))
                && ImpulseTimelapses.OrderBy(it => it.Id).SequenceEqual(other.ImpulseTimelapses.OrderBy(it => it.Id))
                && MedalStatCounts.OrderBy(msc => msc.Id).SequenceEqual(other.MedalStatCounts.OrderBy(msc => msc.Id))
                && MedalTimelapses.OrderBy(mt => mt.Id).SequenceEqual(other.MedalTimelapses.OrderBy(mt => mt.Id));
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

            if (obj.GetType() != typeof (FlexibleStats))
            {
                return false;
            }

            return Equals((FlexibleStats) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ImpulseStatCounts?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (ImpulseTimelapses?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MedalStatCounts?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MedalTimelapses?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(FlexibleStats left, FlexibleStats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FlexibleStats left, FlexibleStats right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class StatTimelapse : IEquatable<StatTimelapse>
    {
        /// <summary>
        /// The ID of the flexible stat.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The amount of time the flexible stat was earned for.
        /// </summary>
        [JsonProperty(PropertyName = "Timelapse")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan Timelapse { get; set; }

        public bool Equals(StatTimelapse other)
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
                && Timelapse.Equals(other.Timelapse);
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

            if (obj.GetType() != typeof (StatTimelapse))
            {
                return false;
            }

            return Equals((StatTimelapse) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode()*397) ^ Timelapse.GetHashCode();
            }
        }

        public static bool operator ==(StatTimelapse left, StatTimelapse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StatTimelapse left, StatTimelapse right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class StatCount : IEquatable<StatCount>
    {
        /// <summary>
        /// The number of times this flexible stat was earned.
        /// </summary>
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// The ID of the flexible stat.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        public bool Equals(StatCount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Count == other.Count
                && Id.Equals(other.Id);
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

            if (obj.GetType() != typeof (StatCount))
            {
                return false;
            }

            return Equals((StatCount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Count*397) ^ Id.GetHashCode();
            }
        }

        public static bool operator ==(StatCount left, StatCount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StatCount left, StatCount right)
        {
            return !Equals(left, right);
        }
    }
}