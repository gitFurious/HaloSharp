using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Stats.CarnageReport.Common;
using HaloSharp.Model.Stats.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport
{
    [Serializable]
    public class ArenaMatch : BaseMatch, IEquatable<ArenaMatch>
    {
        /// <summary>
        /// A list of stats for each player who was present in the match.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerStats")]
        public List<ArenaMatchPlayerStat> PlayerStats { get; set; }

        /// <summary>
        /// A list of stats for each team who in the match. Note that in Free For All modes, there is an entry for 
        /// every player.
        /// </summary>
        [JsonProperty(PropertyName = "TeamStats")]
        public List<TeamStat> TeamStats { get; set; }

        public bool Equals(ArenaMatch other)
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

            if (obj.GetType() != typeof(ArenaMatch))
            {
                return false;
            }

            return Equals((ArenaMatch)obj);
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

        public static bool operator ==(ArenaMatch left, ArenaMatch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaMatch left, ArenaMatch right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaMatchPlayerStat : BasePlayerStat, IEquatable<ArenaMatchPlayerStat>
    {
        /// <summary>
        /// TODO: 
        /// </summary>
        [JsonProperty(PropertyName = "BoostInfo")]
        public BoostInfo BoostInfo { get; set; }

        /// <summary>
        /// Details on any credits the player may have earned from playing this match.
        /// </summary>
        [JsonProperty(PropertyName = "CreditsEarned")]
        public CreditsEarned CreditsEarned { get; set; }

        /// <summary>
        /// The Competitive Skill Ranking (CSR) of the player after the match ended. If the player is still in 
        /// measurement matches, this field is null.
        /// </summary>
        [JsonProperty(PropertyName = "CurrentCsr")]
        public CompetitiveSkillRanking CurrentCsr { get; set; }

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
        /// The player's measurement matches left. If this field is greater than zero, then the player will not have a 
        /// CSR yet. If the player finished the match, this match is included in this count.
        /// </summary>
        [JsonProperty(PropertyName = "MeasurementMatchesLeft")]
        public int MeasurementMatchesLeft { get; set; }

        /// <summary>
        /// The player's progress towards meta commendations. Commendations that had no progress earned this match will 
        /// not be returned. 
        /// </summary>
        [JsonProperty(PropertyName = "MetaCommendationDeltas")]
        public List<MetaCommendationDelta> MetaCommendationDeltas { get; set; }

        /// <summary>
        /// The Competitive Skill Ranking (CSR) of the player before the match started. If the player is still in 
        /// measurement matches, this field is null. If the player finished the last measurement match this match, this 
        /// field is still null.
        /// </summary>
        [JsonProperty(PropertyName = "PreviousCsr")]
        public CompetitiveSkillRanking PreviousCsr { get; set; }

        /// <summary>
        /// The player's progress towards progressive commendations. Commendations that had no progress earned this 
        /// match will not be returned.
        /// </summary>
        [JsonProperty(PropertyName = "ProgressiveCommendationDeltas")]
        public List<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }

        /// <summary>
        /// The set of rewards that the player got in this match.
        /// </summary>
        [JsonProperty(PropertyName = "RewardSets")]
        public List<RewardSet> RewardSets { get; set; }

        /// <summary>
        /// The experience information for the player in this match.
        /// </summary>
        [JsonProperty(PropertyName = "XpInfo")]
        public XpInfo XpInfo { get; set; }

        public bool Equals(ArenaMatchPlayerStat other)
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
                && Equals(BoostInfo, other.BoostInfo)
                && Equals(CurrentCsr, other.CurrentCsr)
                && KilledByOpponentDetails.OrderBy(kbod => kbod.GamerTag).SequenceEqual(other.KilledByOpponentDetails.OrderBy(kbod => kbod.GamerTag))
                && KilledOpponentDetails.OrderBy(kod => kod.GamerTag).SequenceEqual(other.KilledOpponentDetails.OrderBy(kod => kod.GamerTag))
                && MeasurementMatchesLeft == other.MeasurementMatchesLeft
                && MetaCommendationDeltas.OrderBy(mcd => mcd.Id).SequenceEqual(other.MetaCommendationDeltas.OrderBy(mcd => mcd.Id))
                && Equals(PreviousCsr, other.PreviousCsr)
                && ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id).SequenceEqual(other.ProgressiveCommendationDeltas.OrderBy(pcd => pcd.Id))
                && RewardSets.OrderBy(rs => rs.Id).SequenceEqual(other.RewardSets.OrderBy(rs => rs.Id))
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

            if (obj.GetType() != typeof(ArenaMatchPlayerStat))
            {
                return false;
            }

            return Equals((ArenaMatchPlayerStat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (CreditsEarned?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (BoostInfo?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (CurrentCsr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledByOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (KilledOpponentDetails?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MeasurementMatchesLeft;
                hashCode = (hashCode*397) ^ (MetaCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PreviousCsr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ProgressiveCommendationDeltas?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RewardSets?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (XpInfo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(ArenaMatchPlayerStat left, ArenaMatchPlayerStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaMatchPlayerStat left, ArenaMatchPlayerStat right)
        {
            return !Equals(left, right);
        }
    }
}