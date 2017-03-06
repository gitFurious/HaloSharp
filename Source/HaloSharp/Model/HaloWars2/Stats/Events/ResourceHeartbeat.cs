using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.Events
{
    [Serializable]
    public class ResourceHeartbeat : MatchEvent, IEquatable<ResourceHeartbeat>
    {
        [JsonProperty(PropertyName = "TeamResources")]
        public Dictionary<int, TeamResource> TeamResources { get; set; }

        [JsonProperty(PropertyName = "PlayerResources")]
        public Dictionary<int, PlayerResource> PlayerResources { get; set; }

        public bool Equals(ResourceHeartbeat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return PlayerResources.OrderBy(ps => ps.Key).SequenceEqual(other.PlayerResources.OrderBy(ps => ps.Key))
                   && TeamResources.OrderBy(ts => ts.Key).SequenceEqual(other.TeamResources.OrderBy(ts => ts.Key));
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

            if (obj.GetType() != typeof(ResourceHeartbeat))
            {
                return false;
            }

            return Equals((ResourceHeartbeat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((PlayerResources?.GetHashCode() ?? 0) * 397) ^ (TeamResources?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(ResourceHeartbeat left, ResourceHeartbeat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResourceHeartbeat left, ResourceHeartbeat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class TeamResource : IEquatable<TeamResource>
    {
        [JsonProperty(PropertyName = "ObjectiveScore")]
        public int ObjectiveScore { get; set; }

        public bool Equals(TeamResource other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return ObjectiveScore == other.ObjectiveScore;
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

            if (obj.GetType() != typeof(TeamResource))
            {
                return false;
            }

            return Equals((TeamResource)obj);
        }

        public override int GetHashCode()
        {
            return ObjectiveScore;
        }

        public static bool operator ==(TeamResource left, TeamResource right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamResource left, TeamResource right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class PlayerResource : IEquatable<PlayerResource>
    {
        [JsonProperty(PropertyName = "Supply")]
        public int Supply { get; set; }

        [JsonProperty(PropertyName = "TotalSupply")]
        public int TotalSupply { get; set; }

        [JsonProperty(PropertyName = "Energy")]
        public int Energy { get; set; }

        [JsonProperty(PropertyName = "TotalEnergy")]
        public int TotalEnergy { get; set; }

        [JsonProperty(PropertyName = "Population")]
        public int Population { get; set; }

        [JsonProperty(PropertyName = "PopulationCap")]
        public int PopulationCap { get; set; }

        [JsonProperty(PropertyName = "TechLevel")]
        public int TechLevel { get; set; }

        [JsonProperty(PropertyName = "CommandPoints")]
        public int CommandPoints { get; set; }

        [JsonProperty(PropertyName = "TotalCommandPoints")]
        public int TotalCommandPoints { get; set; }

        [JsonProperty(PropertyName = "Mana")]
        public int Mana { get; set; }

        [JsonProperty(PropertyName = "TotalMana")]
        public int TotalMana { get; set; }

        [JsonProperty(PropertyName = "ManaRate")]
        public int ManaRate { get; set; }

        [JsonProperty(PropertyName = "CommandXP")]
        public int CommandExperience { get; set; }

        public bool Equals(PlayerResource other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return CommandExperience == other.CommandExperience
                   && CommandPoints == other.CommandPoints
                   && Energy == other.Energy
                   && Mana == other.Mana
                   && ManaRate == other.ManaRate
                   && Population == other.Population
                   && PopulationCap == other.PopulationCap
                   && Supply == other.Supply
                   && TechLevel == other.TechLevel
                   && TotalCommandPoints == other.TotalCommandPoints
                   && TotalEnergy == other.TotalEnergy
                   && TotalMana == other.TotalMana
                   && TotalSupply == other.TotalSupply;
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

            if (obj.GetType() != typeof(PlayerResource))
            {
                return false;
            }

            return Equals((PlayerResource)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommandExperience;
                hashCode = (hashCode * 397) ^ CommandPoints;
                hashCode = (hashCode * 397) ^ Energy;
                hashCode = (hashCode * 397) ^ Mana;
                hashCode = (hashCode * 397) ^ ManaRate;
                hashCode = (hashCode * 397) ^ Population;
                hashCode = (hashCode * 397) ^ PopulationCap;
                hashCode = (hashCode * 397) ^ Supply;
                hashCode = (hashCode * 397) ^ TechLevel;
                hashCode = (hashCode * 397) ^ TotalCommandPoints;
                hashCode = (hashCode * 397) ^ TotalEnergy;
                hashCode = (hashCode * 397) ^ TotalMana;
                hashCode = (hashCode * 397) ^ TotalSupply;
                return hashCode;
            }
        }

        public static bool operator ==(PlayerResource left, PlayerResource right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlayerResource left, PlayerResource right)
        {
            return !Equals(left, right);
        }
    }
}