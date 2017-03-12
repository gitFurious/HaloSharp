using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.UserGeneratedContent
{
    [Serializable]
    public class GameVariant : IEquatable<GameVariant>
    {
        [JsonProperty(PropertyName = "AccessControl")]
        public Enumeration.Halo5.AccessControl AccessControl { get; set; }

        [JsonProperty(PropertyName = "Banned")]
        public bool Banned { get; set; }

        [JsonProperty(PropertyName = "BaseGame")]
        public Variant BaseGame { get; set; }

        [JsonProperty(PropertyName = "BaseGameEngineType")]
        public int BaseGameEngineType { get; set; }

        [JsonProperty(PropertyName = "CreationTimeUtc")]
        public ISO8601 CreationTimeUtc { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "GameType")]
        public int GameType { get; set; }

        [JsonProperty(PropertyName = "Identity")]
        public Variant Identity { get; set; }

        [JsonProperty(PropertyName = "LastModifiedTimeUtc")]
        public ISO8601 LastModifiedTimeUtc { get; set; }

        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        [JsonProperty(PropertyName = "MatchDurationInSeconds")]
        public int MatchDurationInSeconds { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "NumberOfLives")]
        public int NumberOfLives { get; set; }

        [JsonProperty(PropertyName = "NumberOfRounds")]
        public int NumberOfRounds { get; set; }

        [JsonProperty(PropertyName = "ScoreToWin")]
        public int ScoreToWin { get; set; }

        [JsonProperty(PropertyName = "Stats")]
        public Common.Stats Stats { get; set; }

        public bool Equals(GameVariant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return AccessControl == other.AccessControl
                && Banned == other.Banned
                && Equals(BaseGame, other.BaseGame)
                && BaseGameEngineType == other.BaseGameEngineType
                && Equals(CreationTimeUtc, other.CreationTimeUtc)
                && string.Equals(Description, other.Description)
                && GameType == other.GameType
                && Equals(Identity, other.Identity)
                && Equals(LastModifiedTimeUtc, other.LastModifiedTimeUtc)
                && Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key))
                && MatchDurationInSeconds == other.MatchDurationInSeconds
                && string.Equals(Name, other.Name)
                && NumberOfLives == other.NumberOfLives
                && NumberOfRounds == other.NumberOfRounds
                && ScoreToWin == other.ScoreToWin
                && Equals(Stats, other.Stats);
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

            if (obj.GetType() != typeof(GameVariant))
            {
                return false;
            }

            return Equals((GameVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) AccessControl;
                hashCode = (hashCode*397) ^ Banned.GetHashCode();
                hashCode = (hashCode*397) ^ (BaseGame != null ? BaseGame.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ BaseGameEngineType;
                hashCode = (hashCode*397) ^ (CreationTimeUtc != null ? CreationTimeUtc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ GameType;
                hashCode = (hashCode*397) ^ (Identity != null ? Identity.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastModifiedTimeUtc != null ? LastModifiedTimeUtc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Links?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MatchDurationInSeconds;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ NumberOfLives;
                hashCode = (hashCode*397) ^ NumberOfRounds;
                hashCode = (hashCode*397) ^ ScoreToWin;
                hashCode = (hashCode*397) ^ (Stats != null ? Stats.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameVariant left, GameVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameVariant left, GameVariant right)
        {
            return !Equals(left, right);
        }
    }
}
