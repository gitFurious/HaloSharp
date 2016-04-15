using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using HaloSharp.Model.Stats.Common;
using HaloSharp.Model.Stats.Lifetime.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.Lifetime
{
    [Serializable]
    public class ArenaServiceRecord : BaseServiceRecord, IEquatable<ArenaServiceRecord>
    {
        /// <summary>
        /// Set of responses. One per user queried.
        /// </summary>
        [JsonProperty(PropertyName = "Results")]
        public List<ArenaServiceRecordResult> Results { get; set; }

        public bool Equals(ArenaServiceRecord other)
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
                && Results.OrderBy(r => r.Id).SequenceEqual(other.Results.OrderBy(r => r.Id));
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

            if (obj.GetType() != typeof (ArenaServiceRecord))
            {
                return false;
            }

            return Equals((ArenaServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Results?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(ArenaServiceRecord left, ArenaServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaServiceRecord left, ArenaServiceRecord right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaServiceRecordResult : BaseServiceRecordResult, IEquatable<ArenaServiceRecordResult>
    {
        /// <summary>
        /// The Service Record result for the player. Only set if ResultCode is Success.
        /// </summary>
        [JsonProperty(PropertyName = "Result")]
        public ArenaResult Result { get; set; }

        public bool Equals(ArenaServiceRecordResult other)
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
                && Equals(Result, other.Result);
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

            if (obj.GetType() != typeof (ArenaServiceRecordResult))
            {
                return false;
            }

            return Equals((ArenaServiceRecordResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Result?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(ArenaServiceRecordResult left, ArenaServiceRecordResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaServiceRecordResult left, ArenaServiceRecordResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaResult : BaseResult, IEquatable<ArenaResult>
    {
        /// <summary>
        /// Arena stats data.
        /// </summary>
        [JsonProperty(PropertyName = "ArenaStats")]
        public ArenaStat ArenaStats { get; set; }

        public bool Equals(ArenaResult other)
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
                && Equals(ArenaStats, other.ArenaStats);
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

            if (obj.GetType() != typeof (ArenaResult))
            {
                return false;
            }

            return Equals((ArenaResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (ArenaStats?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(ArenaResult left, ArenaResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaResult left, ArenaResult right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaStat : BaseStat, IEquatable<ArenaStat>
    {
        /// <summary>
        /// List of arena stats by GameBaseVariant across all seasons.
        /// </summary>
        [JsonProperty(PropertyName = "ArenaGameBaseVariantStats")]
        public List<GameBaseVariantStat> ArenaGameBaseVariantStats { get; set; }

        /// <summary>
        /// List of arena stats by playlist.  This is the ONLY set of stats in the response that respects the Season ID 
        /// request parameter. If no Season ID was specified, these will be the stats for the current season. If an 
        /// invalid Season ID was specified, this will be empty.
        /// </summary>
        [JsonProperty(PropertyName = "ArenaPlaylistStats")]
        public List<ArenaPlaylistStat> ArenaPlaylistStats { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "ArenaPlaylistStatsSeasonId")]
        public Guid? ArenaPlaylistStatsSeasonId { get; set; }

        /// <summary>
        /// The highest obtained CSR by the player in arena across all seasons. If the player hasn't finished 
        /// measurement matches yet for any playlist, this value is null.
        /// </summary>
        [JsonProperty(PropertyName = "HighestCsrAttained")]
        public CompetitiveSkillRanking HighestCsrAttained { get; set; }

        /// <summary>
        /// The ID for the playlist that pertains to the highest obtained CSR field across all seasons. If the CSR is 
        /// null, so is this field. 
        /// </summary>
        [JsonProperty(PropertyName = "HighestCsrPlaylistId")]
        public Guid? HighestCsrPlaylistId { get; set; }

        /// <summary>
        /// The ID for the season that pertains to the highest obtained CSR field across all seasons. If the CSR is 
        /// null, so is this field.
        /// </summary>
        [JsonProperty(PropertyName = "HighestCsrSeasonId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid? HighestCsrSeasonId { get; set; }

        /// <summary>
        /// A list of up to 3 game base variants with the highest win rate across all seasons by the user. If there is 
        /// a tie, the game base variant with more completed games is higher. If there's still a tie, game base variant 
        /// IDs are sorted and selected.
        /// </summary>
        [JsonProperty(PropertyName = "TopGameBaseVariants")]
        public List<TopGameBaseVariant> TopGameBaseVariants { get; set; }

        public bool Equals(ArenaStat other)
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
                && ArenaGameBaseVariantStats.OrderBy(agbvs => agbvs.GameBaseVariantId).SequenceEqual(other.ArenaGameBaseVariantStats.OrderBy(agbvs => agbvs.GameBaseVariantId))
                && ArenaPlaylistStats.OrderBy(aps => aps.PlaylistId).SequenceEqual(other.ArenaPlaylistStats.OrderBy(aps => aps.PlaylistId))
                && ArenaPlaylistStatsSeasonId.Equals(other.ArenaPlaylistStatsSeasonId)
                && Equals(HighestCsrAttained, other.HighestCsrAttained)
                && HighestCsrPlaylistId.Equals(other.HighestCsrPlaylistId)
                && HighestCsrSeasonId.Equals(other.HighestCsrSeasonId)
                && TopGameBaseVariants.OrderBy(aps => aps.GameBaseVariantId).SequenceEqual(other.TopGameBaseVariants.OrderBy(aps => aps.GameBaseVariantId));
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

            if (obj.GetType() != typeof (ArenaStat))
            {
                return false;
            }

            return Equals((ArenaStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (ArenaGameBaseVariantStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ArenaPlaylistStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ArenaPlaylistStatsSeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ (HighestCsrAttained?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ HighestCsrPlaylistId.GetHashCode();
                hashCode = (hashCode*397) ^ HighestCsrSeasonId.GetHashCode();
                hashCode = (hashCode*397) ^ (TopGameBaseVariants?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(ArenaStat left, ArenaStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaStat left, ArenaStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class ArenaPlaylistStat : BaseStat, IEquatable<ArenaPlaylistStat>
    {
        /// <summary>
        /// The current Competitive Skill Ranking (CSR) of the player.
        /// </summary>
        [JsonProperty(PropertyName = "Csr")]
        public CompetitiveSkillRanking Csr { get; set; }

        /// <summary>
        /// The highest Competitive Skill Ranking (CSR) achieved by the player. This is included because a player's CSR 
        /// can drop based on performance.
        /// </summary>
        [JsonProperty(PropertyName = "HighestCsr")]
        public CompetitiveSkillRanking HighestCsr { get; set; }

        /// <summary>
        /// The player's measurement matches left. If this field is greater than zero, then the player will not have a 
        /// CSR yet.
        /// </summary>
        [JsonProperty(PropertyName = "MeasurementMatchesLeft")]
        public int MeasurementMatchesLeft { get; set; }

        /// <summary>
        /// The playlist ID. Playlists are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "PlaylistId")]
        public Guid PlaylistId { get; set; }

        public bool Equals(ArenaPlaylistStat other)
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
                && Equals(Csr, other.Csr)
                && Equals(HighestCsr, other.HighestCsr)
                && MeasurementMatchesLeft == other.MeasurementMatchesLeft
                && PlaylistId.Equals(other.PlaylistId);
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

            if (obj.GetType() != typeof (ArenaPlaylistStat))
            {
                return false;
            }

            return Equals((ArenaPlaylistStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (Csr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (HighestCsr?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MeasurementMatchesLeft;
                hashCode = (hashCode*397) ^ PlaylistId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ArenaPlaylistStat left, ArenaPlaylistStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArenaPlaylistStat left, ArenaPlaylistStat right)
        {
            return !Equals(left, right);
        }
    }
}