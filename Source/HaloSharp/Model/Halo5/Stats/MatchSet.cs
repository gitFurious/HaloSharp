using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats
{
    [Serializable]
    public class PlayerMatch : IEquatable<PlayerMatch>
    {
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        [JsonProperty(PropertyName = "GameVariant")]
        public Variant GameVariant { get; set; }

        [JsonProperty(PropertyName = "HopperId")]
        public Guid? HopperId { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public Id Id { get; set; }

        [JsonProperty(PropertyName = "IsTeamGame")]
        public bool IsTeamGame { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        [JsonProperty(PropertyName = "MapId")]
        public Guid MapId { get; set; }

        [JsonProperty(PropertyName = "MapVariant")]
        public Variant MapVariant { get; set; }

        [JsonProperty(PropertyName = "MatchCompletedDate")]
        public ISO8601 MatchCompletedDate { get; set; }

        [JsonProperty(PropertyName = "MatchDuration")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }

        [JsonProperty(PropertyName = "Players")]
        public List<Player> Players { get; set; }

        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

        [JsonProperty(PropertyName = "MatchCompletedDateFidelity")]
        public int MatchCompletedDateFidelity { get; set; }

        [JsonProperty(PropertyName = "Teams")]
        public List<Team> Teams { get; set; }

        public bool Equals(PlayerMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return GameBaseVariantId.Equals(other.GameBaseVariantId)
                && Equals(GameVariant, other.GameVariant)
                && HopperId.Equals(other.HopperId)
                && Equals(Id, other.Id)
                && IsTeamGame == other.IsTeamGame
                && Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && MapId.Equals(other.MapId)
                && Equals(MapVariant, other.MapVariant)
                && Equals(MatchCompletedDate, other.MatchCompletedDate)
                && MatchDuration.Equals(other.MatchDuration)
                && Players.OrderBy(p => p.Identity.Gamertag).SequenceEqual(other.Players.OrderBy(p => p.Identity.Gamertag))
                && SeasonId.Equals(other.SeasonId)
                && MatchCompletedDateFidelity == other.MatchCompletedDateFidelity
                && Teams.OrderBy(t => t.Id).SequenceEqual(other.Teams.OrderBy(t => t.Id));
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

            if (obj.GetType() != typeof (PlayerMatch))
            {
                return false;
            }
            return Equals((PlayerMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GameBaseVariantId.GetHashCode();
                hashCode = (hashCode*397) ^ (GameVariant?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ HopperId.GetHashCode();
                hashCode = (hashCode*397) ^ (Id?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ IsTeamGame.GetHashCode();
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MapId.GetHashCode();
                hashCode = (hashCode*397) ^ (MapVariant?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MatchCompletedDate?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MatchDuration.GetHashCode();
                hashCode = (hashCode*397) ^ (Players?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ SeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ MatchCompletedDateFidelity;
                hashCode = (hashCode*397) ^ (Teams?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(PlayerMatch left, PlayerMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerMatch left, PlayerMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Id : IEquatable<Id>
    {
        [JsonProperty(PropertyName = "GameMode")]
        public Enumeration.Halo5.GameMode GameMode { get; set; }

        [JsonProperty(PropertyName = "MatchId")]
        public Guid MatchId { get; set; }

        public bool Equals(Id other)
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
                && MatchId.Equals(other.MatchId);
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

            if (obj.GetType() != typeof (Id))
            {
                return false;
            }

            return Equals((Id) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) GameMode*397) ^ MatchId.GetHashCode();
            }
        }

        public static bool operator ==(Id left, Id right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Id left, Id right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Player : IEquatable<Player>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Identity { get; set; }

        [JsonProperty(PropertyName = "PostMatchRatings")]
        public object PostMatchRatings { get; set; }

        [JsonProperty(PropertyName = "PreMatchRatings")]
        public object PreMatchRatings { get; set; }

        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "Result")]
        public Enumeration.Halo5.ResultType Result { get; set; }

        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "TotalAssists")]
        public int TotalAssists { get; set; }

        [JsonProperty(PropertyName = "TotalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty(PropertyName = "TotalKills")]
        public int TotalKills { get; set; }

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

            return Equals(Identity, other.Identity)
                && Equals(PostMatchRatings, other.PostMatchRatings)
                && Equals(PreMatchRatings, other.PreMatchRatings)
                && Rank == other.Rank
                && Result == other.Result
                && TeamId == other.TeamId
                && TotalAssists == other.TotalAssists
                && TotalDeaths == other.TotalDeaths
                && TotalKills == other.TotalKills;
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

            if (obj.GetType() != typeof (Player))
            {
                return false;
            }

            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Identity?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (PostMatchRatings?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PreMatchRatings?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Rank;
                hashCode = (hashCode*397) ^ (int) Result;
                hashCode = (hashCode*397) ^ TeamId;
                hashCode = (hashCode*397) ^ TotalAssists;
                hashCode = (hashCode*397) ^ TotalDeaths;
                hashCode = (hashCode*397) ^ TotalKills;
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
    public class Team : IEquatable<Team>
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "Score")]
        public uint Score { get; set; }

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

            return Id == other.Id
                && Rank == other.Rank
                && Score == other.Score;
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

            if (obj.GetType() != typeof (Team))
            {
                return false;
            }

            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ Rank;
                hashCode = (hashCode*397) ^ (int) Score;
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
}