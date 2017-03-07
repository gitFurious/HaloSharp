using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class MatchEnd : MatchEvent, IEquatable<MatchEnd>
    {
        [JsonProperty(PropertyName = "MatchEndReason")]
        public Enumeration.HaloWars2.MatchEndReason MatchEndReason { get; set; }

        [JsonProperty(PropertyName = "VictoryCondition")]
        public Enumeration.HaloWars2.VictoryCondition VictoryCondition { get; set; }

        [JsonProperty(PropertyName = "ActivePlaytimeMilliseconds")]
        [JsonConverter(typeof(MillisecondConverter))]
        public TimeSpan ActivePlaytime { get; set; }

        [JsonProperty(PropertyName = "TeamState")]
        public Dictionary<int, TeamState> TeamStates { get; set; }

        [JsonProperty(PropertyName = "PlayerState")]
        public Dictionary<int, PlayerState> PlayerStates { get; set; }

        public bool Equals(MatchEnd other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return ActivePlaytime.Equals(other.ActivePlaytime)
                   && MatchEndReason == other.MatchEndReason
                   && PlayerStates.OrderBy(ps => ps.Key).SequenceEqual(other.PlayerStates.OrderBy(ps => ps.Key))
                   && TeamStates.OrderBy(ts => ts.Key).SequenceEqual(other.TeamStates.OrderBy(ts => ts.Key))
                   && VictoryCondition == other.VictoryCondition;
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

            if (obj.GetType() != typeof(MatchEnd))
            {
                return false;
            }

            return Equals((MatchEnd)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ActivePlaytime.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)MatchEndReason;
                hashCode = (hashCode * 397) ^ (PlayerStates?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (TeamStates?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int)VictoryCondition;
                return hashCode;
            }
        }

        public static bool operator ==(MatchEnd left, MatchEnd right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchEnd left, MatchEnd right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class TeamState : IEquatable<TeamState>
    {
        [JsonProperty(PropertyName = "ObjectiveScore")]
        public int ObjectiveScore { get; set; }

        [JsonProperty(PropertyName = "MatchOutcome")]
        public Enumeration.HaloWars2.MatchOutcome MatchOutcome { get; set; }

        public bool Equals(TeamState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return MatchOutcome == other.MatchOutcome
                && ObjectiveScore == other.ObjectiveScore;
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

            if (obj.GetType() != typeof(TeamState))
            {
                return false;
            }

            return Equals((TeamState)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)MatchOutcome * 397) ^ ObjectiveScore;
            }
        }

        public static bool operator ==(TeamState left, TeamState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamState left, TeamState right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class PlayerState : IEquatable<PlayerState>
    {
        [JsonProperty(PropertyName = "PersonalScore")]
        public int PersonalScore { get; set; }

        public bool Equals(PlayerState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return PersonalScore == other.PersonalScore;
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

            if (obj.GetType() != typeof(PlayerState))
            {
                return false;
            }

            return Equals((PlayerState)obj);
        }

        public override int GetHashCode()
        {
            return PersonalScore;
        }

        public static bool operator ==(PlayerState left, PlayerState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerState left, PlayerState right)
        {
            return !Equals(left, right);
        }
    }
}