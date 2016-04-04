using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats
{
    [Serializable]
    public class MatchSet : IEquatable<MatchSet>
    {
        /// <summary>
        /// The number of results that the service attempted to retrieve to satisfy this request. Normally this value 
        /// is equal to the "count" parameter. If the client specified a count parameter greater than the maximum 
        /// allowed, this value contains the maximum allowed amount.
        /// </summary>
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// Internal use only. A set of related resource links.
        /// </summary>
        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        /// <summary>
        /// The number of results that are actually being returned in this response. This field is named "ResultCount" 
        /// to avoid confusion with "Count".
        /// </summary>
        [JsonProperty(PropertyName = "ResultCount")]
        public int ResultCount { get; set; }

        /// <summary>
        /// A list of recent matches. Matches are listed in chronological order with the most recently started match 
        /// first.
        /// </summary>
        [JsonProperty(PropertyName = "Results")]
        public List<Result> Results { get; set; }

        /// <summary>
        /// The starting point that was used. When the "start" query string parameter is specified, this value is 
        /// identical. When "start" is omitted, the default value is returned.
        /// </summary>
        [JsonProperty(PropertyName = "Start")]
        public int Start { get; set; }

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
        /// <summary>
        /// The ID of the game base variant for this match. Game base variants are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "GameBaseVariantId")]
        public Guid GameBaseVariantId { get; set; }

        /// <summary>
        /// The variant of the game for this match. There are two sources of game variants: official game variants 
        /// available via the Metadata API and user-generated game variants which are not available via the APIs 
        /// currently. If the game variant for this match was an official game variant, then the structure will be as 
        /// documented here. This will be null for campaign games.
        /// </summary>
        [JsonProperty(PropertyName = "GameVariant")]
        public Variant GameVariant { get; set; }

        /// <summary>
        /// The ID of the playlist (aka "Hopper") for the match. 
        /// <para>Hoppers are used in Arena and Warzone. In Arena, they function just as you would expect, similar to 
        /// previous Halo titles. Warzone uses hoppers as well. There will be multiple Warzone hoppers which contain a 
        /// rotating playlist of scenarios to play.</para>
        /// <para>Null for campaign & custom games. </para>
        /// <para>Playlists are available via the Metadata API.</para>
        /// </summary>
        [JsonProperty(PropertyName = "HopperId")]
        public Guid? HopperId { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public Id Id { get; set; }

        /// <summary>
        /// Whether this was a team-based game or not (e.g. free-for-all).
        /// </summary>
        [JsonProperty(PropertyName = "IsTeamGame")]
        public bool IsTeamGame { get; set; }

        /// <summary>
        /// Internal use only. A set of related resource links.
        /// </summary>
        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        /// <summary>
        /// The ID of the base map for this match. Maps are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "MapId")]
        public Guid MapId { get; set; }

        /// <summary>
        /// The variant of the map for this match. There are two sources of map variants: official map variants 
        /// available via the Metadata API and user-generated map variants which are not available via the APIs 
        /// currently. If the map variant for this match was an official map variant, then the structure will be as 
        /// documented here. This will be null for campaign games.
        /// </summary>
        [JsonProperty(PropertyName = "MapVariant")]
        public Variant MapVariant { get; set; }

        /// <summary>
        /// The date and time when match ended. Note that this is different than the processing date, once matches end 
        /// they typically take a small amount of time to process. The processing date is not available through this 
        /// API. The time component of this date is always set to "00:00:00".
        /// </summary>
        [JsonProperty(PropertyName = "MatchCompletedDate")]
        public MatchCompletedDate MatchCompletedDate { get; set; }

        /// <summary>
        /// The length of the match.
        /// </summary>
        [JsonProperty(PropertyName = "MatchDuration")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }

        /// <summary>
        /// This field contains the player's data. This will only contain data for the player specified in the request.
        /// </summary>
        [JsonProperty(PropertyName = "Players")]
        public List<Player> Players { get; set; }

        /// <summary>
        /// ID for the season the match was played in if it was played in a seasonal playlist and null otherwise. This 
        /// will only be set for Arena matches and will be null for all other game modes.
        /// </summary>
        [JsonProperty(PropertyName = "SeasonId")]
        public Guid? SeasonId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "MatchCompletedDateFidelity")]
        public int MatchCompletedDateFidelity { get; set; }

        /// <summary>
        ///  Provides team data. This list contains all team that Won or Tied. Losing teams are not included. This list 
        /// is empty for campaign games. 
        /// </summary>
        [JsonProperty(PropertyName = "Teams")]
        public List<Team> Teams { get; set; }

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
                hashCode = (hashCode*397) ^ MatchCompletedDateFidelity;
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
        /// <summary>
        /// A list that indicates what game modes this base variant is available within. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Error = 0</description>
        /// </item>
        /// <item>
        /// <description>Arena = 1</description>
        /// </item>
        /// <item>
        /// <description>Campaign = 2</description>
        /// </item>
        /// <item>
        /// <description>Custom = 3</description>
        /// </item>
        /// <item>
        /// <description>Warzone = 4</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "GameMode")]
        public Enumeration.GameMode GameMode { get; set; }

        /// <summary>
        /// The ID for this match. More match details are available via the applicable Post Game Carnage Report 
        /// endpoint.
        /// </summary>
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
    public class MatchCompletedDate : IEquatable<MatchCompletedDate>
    {
        /// <summary>
        /// //TODO
        /// </summary>
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
        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "Player")]
        public Identity Identity { get; set; }

        /// <summary>
        /// Internal use only. This will always be null.
        /// </summary>
        [JsonProperty(PropertyName = "PostMatchRatings")]
        public object PostMatchRatings { get; set; }

        /// <summary>
        /// Internal use only. This will always be null.
        /// </summary>
        [JsonProperty(PropertyName = "PreMatchRatings")]
        public object PreMatchRatings { get; set; }

        /// <summary>
        /// The player's team-agnostic ranking in this match.
        /// </summary>
        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Indicates what result the player received at the conclusion of the match.
        /// <list type="bullet">
        /// <item>
        /// <description>Did Not Finish = 0</description>
        /// </item>
        /// <item>
        /// <description>Lost = 1</description>
        /// </item>
        /// <item>
        /// <description>Tied = 2</description>
        /// </item>
        /// <item>
        /// <description>Won = 3</description>
        /// </item>
        /// </list>
        /// <para>Did Not Finish: The player was not present when the match ended.</para>
        /// <para>Lost: The player was on a team that was assigned a loss, typically this is when a team does not have 
        /// rank = 1. </para>
        /// <para>Won: The player was on the team that was assigned the win, typically this is the team that has 
        /// rank = 1. </para>
        /// <para>Tied: The player was on the team that was awarded a tie. Typically this is when the player is on the 
        /// team with rank = 1, and there is at least one other team with rank = 1. Ties are only for rank = 1 teams. 
        /// Consider the scenario when exactly one team is rank = 1, and two teams are rank = 2. Players on the 
        /// rank = 1 team will have "Won", players on the rank = 2 teams will have "Lost". For ties, this documentation 
        /// states 'typically' because the game may have unique rules for multi-team and FFA scenarios, in which 
        /// multiple teams are awarded a win.</para>
        /// </summary>
        [JsonProperty(PropertyName = "Result")]
        public Enumeration.ResultType Result { get; set; }

        /// <summary>
        /// The ID of the team that the player was on when the match ended. Zero for campaign games.
        /// </summary>
        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// The number of assists credited to the player during the match. This includes other Spartans and Enemy AI.
        /// </summary>
        [JsonProperty(PropertyName = "TotalAssists")]
        public int TotalAssists { get; set; }

        /// <summary>
        /// The number of times this player died during the match.
        /// </summary>
        [JsonProperty(PropertyName = "TotalDeaths")]
        public int TotalDeaths { get; set; }

        /// <summary>
        /// The number of enemy kills the player had during this match. This includes other Spartans and Enemy AI.
        /// </summary>
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
        /// <summary>
        /// The ID for the team. The team's ID dictates the team's color. Team colors are available via the Metadata 
        /// API.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// The team's rank at the end of the match.
        /// </summary>
        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        /// <summary>
        /// The team's score at the end of the match. The way the score is determined is based off the game base 
        /// variant being played: 
        /// <list type="bullet">
        /// <item>
        /// <description>Breakout = number of rounds won</description>
        /// </item>
        /// <item>
        /// <description>CTF = number of flag captures</description>
        /// </item>
        /// <item>
        /// <description>Slayer = number of kills</description>
        /// </item>
        /// <item>
        /// <description>Strongholds = number of points</description>
        /// </item>
        /// <item>
        /// <description>Warzone = number of points</description>
        /// </item>
        /// </list>
        /// </summary>
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