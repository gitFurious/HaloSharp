using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats
{
    public class MatchSet
    {
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<Result> Results { get; set; }
        public int Start { get; set; }

        // Internal use only.
        public Dictionary<string, Link> Links { get; set; }
    }

    public class Result
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
    }

    public class Id
    {
        public Enumeration.GameMode GameMode { get; set; }
        public Guid MatchId { get; set; }
    }

    public class Variant
    {
        public string Owner { get; set; }
        public Enumeration.OwnerType OwnerType { get; set; }
        public Guid ResourceId { get; set; }
        public Enumeration.ResourceType ResourceType { get; set; }
    }

    public class MatchCompletedDate
    {
        // ReSharper disable once InconsistentNaming
        public DateTime ISO8601Date { get; set; }
    }

    public class Player
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
    }

    public class Team
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public uint Score { get; set; }
    }
}