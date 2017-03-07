using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport
{
    [Serializable]
    public class MatchEventSummary : IEquatable<MatchEventSummary>
    {
        [JsonProperty(PropertyName = "GameEvents")]
        [JsonConverter(typeof(HaloWars2MatchEventConverter))]
        public List<MatchEvent> MatchEvents { get; set; }

        [JsonProperty(PropertyName = "IsCompleteSetOfEvents")]
        public bool IsCompleteSetOfEvents { get; set; }

        public bool Equals(MatchEventSummary other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return IsCompleteSetOfEvents == other.IsCompleteSetOfEvents
                && MatchEvents.OrderBy(me => me.TimeSinceStart).SequenceEqual(other.MatchEvents.OrderBy(me => me.TimeSinceStart));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(MatchEventSummary))
            {
                return false;
            }

            return Equals((MatchEventSummary)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (IsCompleteSetOfEvents.GetHashCode() * 397) ^ (MatchEvents?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(MatchEventSummary left, MatchEventSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchEventSummary left, MatchEventSummary right)
        {
            return !Equals(left, right);
        }
    }
}
