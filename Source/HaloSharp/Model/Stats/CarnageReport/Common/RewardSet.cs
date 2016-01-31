using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class RewardSet : IEquatable<RewardSet>
    {
        /// <summary>
        /// If the Reward Source is a Commendation, this is the ID of the level of the commendation that earned the 
        /// reward.
        /// </summary>
        [JsonProperty(PropertyName = "CommendationLevelId")]
        public Guid? CommendationLevelId { get; set; }

        /// <summary>
        /// If the Reward Source is a Meta Commendation or Progress Commendation, this is the ID of the Meta 
        /// Commendation or Progress Commendation, respectively, that earned the reward. Commendations are available 
        /// via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "CommendationSource")]
        public Guid? CommendationSource { get; set; }

        /// <summary>
        /// The ID of the reward.
        /// </summary>
        [JsonProperty(PropertyName = "RewardSet")]
        public Guid Id { get; set; }

        /// <summary>
        /// The source of the reward. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>None = 0</description>
        /// </item>
        /// <item>
        /// <description>Meta Commendation = 1</description>
        /// </item>
        /// <item>
        /// <description>Progress Commendation = 2</description>
        /// </item>
        /// <item>
        /// <description>Spartan Rank = 3</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "RewardSourceType")]
        public Enumeration.RewardSourceType RewardSourceType { get; set; }

        /// <summary>
        /// If the Reward Source is Spartan Rank, this value is set to the Spartan Rank the player acquired that led to 
        /// this reward being granted. Note: Unlike the commendations fields in this structure, this is not the GUID to 
        /// a Spartan Rank content item. That's because the Spartan Rank content item itself does not detail what 
        /// specific Spartan Rank it pertains to - this information is derived from the list of Spartan Ranks as a 
        /// whole. Spartan Ranks are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "SpartanRankSource")]
        public int? SpartanRankSource { get; set; }

        public bool Equals(RewardSet other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CommendationLevelId.Equals(other.CommendationLevelId)
                && CommendationSource.Equals(other.CommendationSource)
                && Id.Equals(other.Id)
                && RewardSourceType == other.RewardSourceType
                && SpartanRankSource == other.SpartanRankSource;
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

            if (obj.GetType() != typeof (RewardSet))
            {
                return false;
            }

            return Equals((RewardSet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommendationLevelId.GetHashCode();
                hashCode = (hashCode*397) ^ CommendationSource.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (int) RewardSourceType;
                hashCode = (hashCode*397) ^ SpartanRankSource.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(RewardSet left, RewardSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RewardSet left, RewardSet right)
        {
            return !Equals(left, right);
        }
    }
}