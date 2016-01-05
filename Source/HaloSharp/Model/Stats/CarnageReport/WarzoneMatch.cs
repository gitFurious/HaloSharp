using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Stats.CarnageReport.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class WarzoneMatch : BaseMatch, IEquatable<WarzoneMatch>
    {
        /// <summary>
        /// A list of stats for each player who was present in the match.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<WarzonePlayerStat> PlayerStats { get; set; }

        /// <summary>
        /// A list of stats for each team who in the match. Note that in Free For All modes, there is an entry for 
        /// every player.
        /// </summary>
        [JsonProperty(PropertyName = "TeamStats")]
        public List<TeamStat> TeamStats { get; set; }

        public bool Equals(WarzoneMatch other)
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
                && PlayerStats.OrderBy(ps => ps.Player.Gamertag).SequenceEqual(other.PlayerStats.OrderBy(ps => ps.Player.Gamertag))
                && TeamStats.OrderBy(ts => ts.TeamId).SequenceEqual(other.TeamStats.OrderBy(ts => ts.TeamId));
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

            if (obj.GetType() != typeof (WarzoneMatch))
            {
                return false;
            }

            return Equals((WarzoneMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (PlayerStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TeamStats?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(WarzoneMatch left, WarzoneMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzoneMatch left, WarzoneMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WarzonePlayerStat : BasePlayerStat, IEquatable<WarzonePlayerStat>
    {
        /// <summary>
        /// Details on any credits the player may have earned from playing this match.
        /// </summary>
        [JsonProperty(PropertyName = "CreditsEarned")]
        public CreditsEarned CreditsEarned { get; set; }

        /// <summary>
        /// The number of times the player was killed by each opponent. If the player was not killed by an opponent, 
        /// there will be no entry for that opponent.
        /// </summary>
        [JsonProperty(PropertyName = "KilledByOpponentDetails")]
        public List<OpponentDetails> KilledByOpponentDetails { get; set; }

        /// <summary>
        /// The number of times the player killed each opponent. If the player did not kill an opponent, there will be 
        /// no entry for that opponent.
        /// </summary>
        [JsonProperty(PropertyName = "KilledOpponentDetails")]
        public List<OpponentDetails> KilledOpponentDetails { get; set; }

        /// <summary>
        /// The player's progress towards meta commendations. Commendations that had no progress earned this match will 
        /// not be returned. 
        /// </summary>
        [JsonProperty(PropertyName = "MetaCommendationDeltas")]
        public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }

        /// <summary>
        /// The player's progress towards progressive commendations. Commendations that had no progress earned this 
        /// match will not be returned.
        /// </summary>
        [JsonProperty(PropertyName = "ProgressiveCommendationDeltas")]
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }

        /// <summary>
        /// The set of rewards that the player got in this match. Rewards are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "RewardSets")]
        public List<RewardSet> RewardSets { get; set; }

        /// <summary>
        /// The total number of "pies" (in-game currency) the player earned in the match.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPiesEarned")]
        public int TotalPiesEarned { get; set; }

        /// <summary>
        /// The maximum level the player achieved in the match.
        /// </summary>
        [JsonProperty(PropertyName = "WarzoneLevel")]
        public int WarzoneLevel { get; set; }

        /// <summary>
        /// The experience information for the player in this match.
        /// </summary>
        [JsonProperty(PropertyName = "XpInfo")]
        public XpInfo XpInfo { get; set; }

        public bool Equals(WarzonePlayerStat other)
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
                && Equals(CreditsEarned, other.CreditsEarned)
                && KilledByOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(od => od.GamerTag))
                && KilledOpponentDetails.OrderBy(od => od.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(od => od.GamerTag))
                && MetaCommendationDeltas.OrderBy(mcd => mcd.Id).SequenceEqual(other.MetaCommendationDeltas.OrderBy(mcd => mcd.Id))
                && ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id).SequenceEqual(other.ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id))
                && RewardSets.OrderBy(rs => rs.Id).SequenceEqual(other.RewardSets.OrderBy(rs => rs.Id))
                && TotalPiesEarned == other.TotalPiesEarned
                && WarzoneLevel == other.WarzoneLevel
                && Equals(XpInfo, other.XpInfo);
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

            if (obj.GetType() != typeof (WarzonePlayerStat))
            {
                return false;
            }

            return Equals((WarzonePlayerStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CreditsEarned?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledByOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MetaCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ProgressiveCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RewardSets?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalPiesEarned;
                hashCode = (hashCode*397) ^ WarzoneLevel;
                hashCode = (hashCode*397) ^ (XpInfo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(WarzonePlayerStat left, WarzonePlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WarzonePlayerStat left, WarzonePlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}