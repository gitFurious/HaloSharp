using HaloSharp.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class FlexibleStats : IEquatable<FlexibleStats>
    {
        public List<StatCount> ImpulseStatCounts { get; set; }
        public List<StatTimelapse> ImpulseTimelapses { get; set; }
        public List<StatCount> MedalStatCounts { get; set; }
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
        public Guid Id { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
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
        public int Count { get; set; }
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