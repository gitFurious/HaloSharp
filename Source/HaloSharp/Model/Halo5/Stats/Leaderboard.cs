using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Halo5.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats
{
    [Serializable]
    public class Leaderboard : IEquatable<Leaderboard>
    {
        /// <summary>
        ///     Internal use only. A set of related resource links.
        /// </summary>
        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        /// <summary>
        ///     The starting point that was used. Will always be 0.
        /// </summary>
        [JsonProperty(PropertyName = "Start")]
        public int Start { get; set; }

        /// <summary>
        ///     The number of results that the service attempted to retrieve to satisfy this request. Normally this value is equal
        ///     to the "count" parameter. If the client specified a count parameter greater than the maximum allowed, this value
        ///     contains the maximum allowed amount.
        /// </summary>
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        /// <summary>
        ///     The number of results that are actually being returned in this response. This field is named "ResultCount" to avoid
        ///     confusion with "Count".
        /// </summary>
        [JsonProperty(PropertyName = "ResultCount")]
        public int ResultCount { get; set; }

        /// <summary>
        ///     A list of players in the leaderboard. Players are listed in chronological order with the player with the highest
        ///     CSR first.
        /// </summary>
        [JsonProperty(PropertyName = "Results")]
        public List<LeaderboardResult> Results { get; set; }

        public bool Equals(Leaderboard other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && Start == other.Start
                && Count == other.Count
                && ResultCount == other.ResultCount
                && Results.OrderBy(r => r.Player.Gamertag).SequenceEqual(other.Results.OrderBy(r => r.Player.Gamertag));
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

            if (obj.GetType() != typeof (Leaderboard))
            {
                return false;
            }

            return Equals((Leaderboard) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Links?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Start;
                hashCode = (hashCode*397) ^ Count;
                hashCode = (hashCode*397) ^ ResultCount;
                hashCode = (hashCode*397) ^ (Results?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(Leaderboard left, Leaderboard right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Leaderboard left, Leaderboard right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class LeaderboardResult : IEquatable<LeaderboardResult>
    {
        /// <summary>
        ///     Information about the player for whom this data was returned.
        /// </summary>
        [JsonProperty(PropertyName = "Player")]
        public Identity Player { get; set; }

        /// <summary>
        ///     The player's rank in the leaderboard.
        /// </summary>
        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        /// <summary>
        ///     The Competitive Skill Ranking (CSR) of the player.
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        public CompetitiveSkillRanking Score { get; set; }

        public bool Equals(LeaderboardResult other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Player, other.Player)
                && Rank == other.Rank
                && Equals(Score, other.Score);
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

            if (obj.GetType() != typeof (LeaderboardResult))
            {
                return false;
            }

            return Equals((LeaderboardResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Player?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Rank;
                hashCode = (hashCode*397) ^ (Score?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(LeaderboardResult left, LeaderboardResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LeaderboardResult left, LeaderboardResult right)
        {
            return !Equals(left, right);
        }
    }
}