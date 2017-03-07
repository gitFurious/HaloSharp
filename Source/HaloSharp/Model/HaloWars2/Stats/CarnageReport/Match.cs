using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using HaloSharp.Model.HaloWars2.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport
{
    [Serializable]
    public class Match : IEquatable<Match>
    {
        [JsonProperty(PropertyName = "MatchId")]
        public Guid MatchId { get; set; }

        [JsonProperty(PropertyName = "MatchType")]
        public Enumeration.HaloWars2.MatchType MatchType { get; set; }

        [JsonProperty(PropertyName = "GameMode")]
        public Enumeration.HaloWars2.GameMode GameMode { get; set; }

        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid? PlaylistId { get; set; }

        [JsonProperty(PropertyName = "MapId")] 
        public string MapId { get; set; } 

        [JsonProperty(PropertyName = "IsMatchComplete")]
        public bool IsMatchComplete { get; set; } // uni

        [JsonProperty(PropertyName = "MatchEndReason")]
        public Enumeration.HaloWars2.MatchEndReason? MatchEndReason { get; set; } // uni

        [JsonProperty(PropertyName = "VictoryCondition")]
        public Enumeration.HaloWars2.VictoryCondition? VictoryCondition { get; set; } // uni

        [JsonProperty(PropertyName = "MatchStartDate")]
        public ISO8601 MatchStartDate { get; set; }

        [JsonProperty(PropertyName = "MatchDuration")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }

        [JsonProperty(PropertyName = "Teams")]
        public Dictionary<int, Team> Teams { get; set; }

        [JsonProperty(PropertyName = "Players")]
        public Dictionary<int, Player> Players { get; set; }

        public bool Equals(Match other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return GameMode == other.GameMode
				&& IsMatchComplete == other.IsMatchComplete
				&& string.Equals(MapId, other.MapId)
				&& MatchDuration.Equals(other.MatchDuration)
				&& MatchEndReason == other.MatchEndReason
				&& MatchId.Equals(other.MatchId)
				&& Equals(MatchStartDate, other.MatchStartDate)
				&& MatchType == other.MatchType
				&& Players.OrderBy(p => p.Key).SequenceEqual(other.Players.OrderBy(p => p.Key))
                && PlaylistId.Equals(other.PlaylistId)
				&& SeasonId.Equals(other.SeasonId)
				&& Teams.OrderBy(t => t.Key).SequenceEqual(other.Teams.OrderBy(t => t.Key))
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
				return true;
			}

            if (obj.GetType() != typeof(Match))
			{
				return false;
			}

            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) GameMode;
                hashCode = (hashCode*397) ^ IsMatchComplete.GetHashCode();
                hashCode = (hashCode*397) ^ (MapId?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MatchDuration.GetHashCode();
                hashCode = (hashCode*397) ^ MatchEndReason.GetHashCode();
                hashCode = (hashCode*397) ^ MatchId.GetHashCode();
                hashCode = (hashCode*397) ^ (MatchStartDate != null ? MatchStartDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) MatchType;
                hashCode = (hashCode*397) ^ (Players?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ SeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ (Teams?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ VictoryCondition.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Match left, Match right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Match left, Match right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Team : Common.Team, IEquatable<Team>
    {
        [JsonProperty(PropertyName = "MatchOutcome")]
        public Enumeration.HaloWars2.MatchOutcome? MatchOutcome { get; set; }

        [JsonProperty(PropertyName = "ObjectiveScore")]
        public int? ObjectiveScore { get; set; }

        public bool Equals(Team other)
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
				&& MatchOutcome == other.MatchOutcome
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
				return true;
			}

            if (obj.GetType() != typeof(Team))
			{
				return false;
			}

            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ MatchOutcome.GetHashCode();
                hashCode = (hashCode*397) ^ ObjectiveScore.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Player : IEquatable<Player>
    {
        [JsonProperty(PropertyName = "IsHuman")]
        public bool IsHuman { get; set; }

        [JsonProperty(PropertyName = "HumanPlayerId")]
        public Identity HumanPlayerId { get; set; }

        [JsonProperty(PropertyName = "ComputerPlayerId")]
        public int? ComputerPlayerId { get; set; }

        [JsonProperty(PropertyName = "ComputerDifficulty")]
        public int? ComputerDifficulty { get; set; }

        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "TeamPlayerIndex")]
        public int TeamPlayerIndex { get; set; }

        [JsonProperty(PropertyName = "LeaderId")]
        public int LeaderId { get; set; }

        [JsonProperty(PropertyName = "PlayerCompletedMatch")]
        public bool? PlayerCompletedMatch { get; set; }

        [JsonProperty(PropertyName = "TimeInMatch")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? TimeInMatch { get; set; }

        [JsonProperty(PropertyName = "PlayerMatchOutcome")]
        public Enumeration.HaloWars2.MatchOutcome? PlayerMatchOutcome { get; set; }

        [JsonProperty(PropertyName = "PointStats")]
        public Dictionary<string, PointStat> PointStats { get; set; }

        [JsonProperty(PropertyName = "UnitStats")]
        public Dictionary<string, UnitStat> UnitStats { get; set; }

        [JsonProperty(PropertyName = "CardStats")]
        public Dictionary<Guid, CardStat> CardStats { get; set; }

        [JsonProperty(PropertyName = "WaveStats")]
        public Dictionary<int, WaveStat> WaveStats { get; set; }

        [JsonProperty(PropertyName = "LeaderPowerStats")]
        public Dictionary<string, LeaderPowerStat> LeaderPowerStats { get; set; }

        [JsonProperty(PropertyName = "XPProgress")]
        public ExperienceProgress ExperienceProgress { get; set; }

        [JsonProperty(PropertyName = "RatingProgress")]
        public RatingProgress RatingProgress { get; set; }

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return CardStats.OrderBy(cs => cs.Key).SequenceEqual(other.CardStats.OrderBy(cs => cs.Key))
                && ComputerDifficulty == other.ComputerDifficulty
				&& ComputerPlayerId == other.ComputerPlayerId
				&& Equals(ExperienceProgress, other.ExperienceProgress)
				&& Equals(HumanPlayerId, other.HumanPlayerId)
				&& IsHuman == other.IsHuman
				&& LeaderId == other.LeaderId
				&& LeaderPowerStats.OrderBy(lps => lps.Key).SequenceEqual(other.LeaderPowerStats.OrderBy(lps => lps.Key))
                && PlayerCompletedMatch == other.PlayerCompletedMatch
				&& PlayerMatchOutcome == other.PlayerMatchOutcome
				&& PointStats.OrderBy(p => p.Key).SequenceEqual(other.PointStats.OrderBy(p => p.Key))
                && Equals(RatingProgress, other.RatingProgress)
				&& TeamId == other.TeamId
				&& TeamPlayerIndex == other.TeamPlayerIndex
				&& TimeInMatch.Equals(other.TimeInMatch)
				&& UnitStats.OrderBy(us => us.Key).SequenceEqual(other.UnitStats.OrderBy(us => us.Key))
                && WaveStats.OrderBy(ws => ws.Key).SequenceEqual(other.WaveStats.OrderBy(ws => ws.Key));
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

            if (obj.GetType() != typeof(Player))
			{
				return false;
			}

            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CardStats?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ ComputerDifficulty.GetHashCode();
                hashCode = (hashCode*397) ^ ComputerPlayerId.GetHashCode();
                hashCode = (hashCode*397) ^ (ExperienceProgress != null ? ExperienceProgress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (HumanPlayerId != null ? HumanPlayerId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsHuman.GetHashCode();
                hashCode = (hashCode*397) ^ LeaderId;
                hashCode = (hashCode*397) ^ (LeaderPowerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ PlayerCompletedMatch.GetHashCode();
                hashCode = (hashCode*397) ^ PlayerMatchOutcome.GetHashCode();
                hashCode = (hashCode*397) ^ (PointStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RatingProgress != null ? RatingProgress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TeamId;
                hashCode = (hashCode*397) ^ TeamPlayerIndex;
                hashCode = (hashCode*397) ^ TimeInMatch.GetHashCode();
                hashCode = (hashCode*397) ^ (UnitStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (WaveStats?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class PointStat : IEquatable<PointStat>
    {
        [JsonProperty(PropertyName = "TimesCaptured")]
        public int TimesCaptured { get; set; }

        public bool Equals(PointStat other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return TimesCaptured == other.TimesCaptured;
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

            if (obj.GetType() != typeof(PointStat))
			{
				return false;
			}

            return Equals((PointStat) obj);
        }

        public override int GetHashCode()
        {
            return TimesCaptured;
        }

        public static bool operator ==(PointStat left, PointStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PointStat left, PointStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class UnitStat : IEquatable<UnitStat>
    {
        [JsonProperty(PropertyName = "TotalBuilt")]
        public int TotalBuilt { get; set; }

        [JsonProperty(PropertyName = "TotalLost")]
        public int TotalLost { get; set; }

        [JsonProperty(PropertyName = "TotalDestroyed")]
        public int TotalDestroyed { get; set; }

        public bool Equals(UnitStat other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return TotalBuilt == other.TotalBuilt
				&& TotalDestroyed == other.TotalDestroyed
				&& TotalLost == other.TotalLost;
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

            if (obj.GetType() != typeof(UnitStat))
			{
				return false;
			}

            return Equals((UnitStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TotalBuilt;
                hashCode = (hashCode*397) ^ TotalDestroyed;
                hashCode = (hashCode*397) ^ TotalLost;
                return hashCode;
            }
        }

        public static bool operator ==(UnitStat left, UnitStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitStat left, UnitStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CardStat : IEquatable<CardStat>
    {
        [JsonProperty(PropertyName = "TotalPlays")]
        public int TotalPlays { get; set; }

        public bool Equals(CardStat other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return TotalPlays == other.TotalPlays;
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

            if (obj.GetType() != typeof(CardStat))
			{
				return false;
			}

            return Equals((CardStat) obj);
        }

        public override int GetHashCode()
        {
            return TotalPlays;
        }

        public static bool operator ==(CardStat left, CardStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardStat left, CardStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WaveStat : IEquatable<WaveStat>
    {
        [JsonProperty(PropertyName = "WaveDuration")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan WaveDuration { get; set; }

        public bool Equals(WaveStat other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return WaveDuration.Equals(other.WaveDuration);
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

            if (obj.GetType() != typeof(WaveStat))
			{
				return false;
			}

            return Equals((WaveStat) obj);
        }

        public override int GetHashCode()
        {
            return WaveDuration.GetHashCode();
        }

        public static bool operator ==(WaveStat left, WaveStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WaveStat left, WaveStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class LeaderPowerStat : IEquatable<LeaderPowerStat>
    {
        [JsonProperty(PropertyName = "TimesCast")]
        public int TimesCast { get; set; }

        public bool Equals(LeaderPowerStat other)
        {
            if (ReferenceEquals(null, other))
			{
				return false;
			}

            if (ReferenceEquals(this, other))
			{
				return true;
			}

            return TimesCast == other.TimesCast;
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

            if (obj.GetType() != typeof(LeaderPowerStat))
			{
				return false;
			}

            return Equals((LeaderPowerStat) obj);
        }

        public override int GetHashCode()
        {
            return TimesCast;
        }

        public static bool operator ==(LeaderPowerStat left, LeaderPowerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeaderPowerStat left, LeaderPowerStat right)
        {
            return !Equals(left, right);
        }
    }
}
