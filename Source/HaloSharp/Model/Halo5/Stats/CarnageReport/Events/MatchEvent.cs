﻿using System;
using HaloSharp.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Stats.CarnageReport.Events
{
    [Serializable]
    public class MatchEvent : IEquatable<MatchEvent>
    {
        [JsonProperty(PropertyName = "EventName")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.Halo5.MatchEventType MatchEventType { get; set; }

        [JsonProperty(PropertyName = "TimeSinceStart")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }

        public bool Equals(MatchEvent other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return MatchEventType == other.MatchEventType
                   && TimeSinceStart.Equals(other.TimeSinceStart);
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

            if (obj.GetType() != typeof(MatchEvent))
            {
                return false;
            }

            return Equals((MatchEvent)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)MatchEventType * 397) ^ TimeSinceStart.GetHashCode();
            }
        }

        public static bool operator ==(MatchEvent left, MatchEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchEvent left, MatchEvent right)
        {
            return !Equals(left, right);
        }
    }
}