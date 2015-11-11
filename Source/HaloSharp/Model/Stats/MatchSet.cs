using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats
{
    [Serializable]
    public class MatchSet : IEquatable<MatchSet>
    {
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<Result> Results { get; set; }
        public int Start { get; set; }

        // Internal use only.
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(MatchSet other)
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
                && Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && ResultCount == other.ResultCount
                && Results.OrderBy(r => r.Id.MatchId).SequenceEqual(other.Results.OrderBy(r => r.Id.MatchId))
                && Start == other.Start;
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

            if (obj.GetType() != typeof (MatchSet))
            {
                return false;
            }

            return Equals((MatchSet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Count;
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ResultCount;
                hashCode = (hashCode*397) ^ (Results?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Start;
                return hashCode;
            }
        }

        public static bool operator ==(MatchSet left, MatchSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchSet left, MatchSet right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Result : IEquatable<Result>
    {
        public Guid GameBaseVariantId { get; set; }
        public Variant GameVariant { get; set; }
        public Guid? HopperId { get; set; }
        public Id Id { get; set; }
        public bool IsTeamGame { get; set; }
        public Guid MapId { get; set; }
        public Variant MapVariant { get; set; }
        public MatchCompletedDate MatchCompletedDate { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }

        public List<Player> Players { get; set; }
        public List<Team> Teams { get; set; }

        // Internal use only.
        public Dictionary<string, Link> Links { get; set; }
        public Guid? SeasonId { get; set; }

        public bool Equals(Result other)
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

            if (obj.GetType() != typeof (Result))
            {
                return false;
            }

            return Equals((Result) obj);
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
                hashCode = (hashCode*397) ^ (Teams?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Result left, Result right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Result left, Result right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Id : IEquatable<Id>
    {
        public Enumeration.GameMode GameMode { get; set; }
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
    public class Variant : IEquatable<Variant>
    {
        public string Owner { get; set; }
        public Enumeration.OwnerType OwnerType { get; set; }
        public Guid ResourceId { get; set; }
        public Enumeration.ResourceType ResourceType { get; set; }

        public bool Equals(Variant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Owner, other.Owner)
                && OwnerType == other.OwnerType
                && ResourceId.Equals(other.ResourceId)
                && ResourceType == other.ResourceType;
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

            if (obj.GetType() != typeof (Variant))
            {
                return false;
            }

            return Equals((Variant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Owner?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) OwnerType;
                hashCode = (hashCode*397) ^ ResourceId.GetHashCode();
                hashCode = (hashCode*397) ^ (int) ResourceType;
                return hashCode;
            }
        }

        public static bool operator ==(Variant left, Variant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Variant left, Variant right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class MatchCompletedDate : IEquatable<MatchCompletedDate>
    {
        // ReSharper disable once InconsistentNaming
        public DateTime ISO8601Date { get; set; }

        public bool Equals(MatchCompletedDate other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ISO8601Date.Equals(other.ISO8601Date);
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

            if (obj.GetType() != typeof (MatchCompletedDate))
            {
                return false;
            }

            return Equals((MatchCompletedDate) obj);
        }

        public override int GetHashCode()
        {
            return ISO8601Date.GetHashCode();
        }

        public static bool operator ==(MatchCompletedDate left, MatchCompletedDate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MatchCompletedDate left, MatchCompletedDate right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Player : IEquatable<Player>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Identity { get; set; }
        
        public int Rank { get; set; }
        public Enumeration.ResultType Result { get; set; }
        public int TeamId { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalKills { get; set; }

        // Internal use only.
        //public object PostMatchRatings { get; set; } //This will always be null.
        //public object PreMatchRatings { get; set; } //This will always be null.

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
        public int Id { get; set; }
        public int Rank { get; set; }
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