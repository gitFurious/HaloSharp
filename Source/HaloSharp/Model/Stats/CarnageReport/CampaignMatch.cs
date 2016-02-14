using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Stats.CarnageReport.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class CampaignMatch : BaseMatch, IEquatable<CampaignMatch>
    {
        /// <summary>
        /// The difficulty the mission was played at. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Easy = 0</description>
        /// </item>
        /// <item>
        /// <description>Normal = 1</description>
        /// </item>
        /// <item>
        /// <description>Heroic = 2</description>
        /// </item>
        /// <item>
        /// <description>Legendary = 3</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "Difficulty")]
        public Enumeration.Difficulty Difficulty { get; set; }

        /// <summary>
        /// Indicates whether the mission was completed when the match ended.
        /// </summary>
        [JsonProperty(PropertyName = "MissionCompleted")]
        public bool MissionCompleted { get; set; }

        /// <summary>
        /// A list of stats for each player who was present in the match.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<CampaignMatchPlayerStat> PlayerStats { get; set; }

        /// <summary>
        /// The list of skulls used for the mission. Skulls are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "Skulls")]
        public List<int> Skulls { get; set; }

        /// <summary>
        /// The total playthrough time of the mission as calculated by the game. This value is persisted in save files.
        /// </summary>
        [JsonProperty(PropertyName = "TotalMissionPlaythroughTime")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan TotalMissionPlaythroughTime { get; set; }

        public bool Equals(CampaignMatch other)
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
                && Difficulty == other.Difficulty
                && MissionCompleted == other.MissionCompleted
                && PlayerStats.OrderBy(ps => ps.Player.Gamertag).SequenceEqual(other.PlayerStats.OrderBy(ps => ps.Player.Gamertag))
                && Skulls.OrderBy(s => s).SequenceEqual(other.Skulls.OrderBy(s => s))
                && TotalMissionPlaythroughTime.Equals(other.TotalMissionPlaythroughTime);
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

            if (obj.GetType() != typeof (CampaignMatch))
            {
                return false;
            }

            return Equals((CampaignMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (int) Difficulty;
                hashCode = (hashCode*397) ^ MissionCompleted.GetHashCode();
                hashCode = (hashCode*397) ^ (PlayerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Skulls?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalMissionPlaythroughTime.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMatch left, CampaignMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMatch left, CampaignMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CampaignMatchPlayerStat : BasePlayerStat, IEquatable<CampaignMatchPlayerStat>
    {
        /// <summary>
        /// The player's biggest score due to a kill.
        /// </summary>
        [JsonProperty(PropertyName = "BiggestKillScore")]
        public int BiggestKillScore { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonProperty(PropertyName = "CharacterIndex")]
        public int? CharacterIndex { get; set; }

        /// <summary>
        /// The player's score.
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        public int Score { get; set; }

        public bool Equals(CampaignMatchPlayerStat other)
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
                && BiggestKillScore == other.BiggestKillScore
                && CharacterIndex == other.CharacterIndex 
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

            if (obj.GetType() != typeof (CampaignMatchPlayerStat))
            {
                return false;
            }

            return Equals((CampaignMatchPlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ BiggestKillScore;
                hashCode = (hashCode*397) ^ CharacterIndex.GetHashCode();
                hashCode = (hashCode*397) ^ Score;
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMatchPlayerStat left, CampaignMatchPlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMatchPlayerStat left, CampaignMatchPlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}