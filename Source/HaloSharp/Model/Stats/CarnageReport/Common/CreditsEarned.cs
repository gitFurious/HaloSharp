using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class CreditsEarned : IEquatable<CreditsEarned>
    {
        /// <summary>
        /// The portion of credits earned due to the boost card the user applied.
        /// </summary>
        [JsonProperty(PropertyName = "BoostAmount")]
        public int BoostAmount { get; set; }

        /// <summary>
        /// The portion of credits earned due to the player's team-agnostic rank in the match.
        /// </summary>
        [JsonProperty(PropertyName = "PlayerRankAmount")]
        public int PlayerRankAmount { get; set; }

        /// <summary>
        /// Indicates how the credits result was arrived at. Options are:
        /// <list type="bullet">
        /// <item>
        /// <description>Credits Disabled In Playlist = 0</description>
        /// </item>
        /// <item>
        /// <description>Player Did Not Finish = 1</description>
        /// </item>
        /// <item>
        /// <description>Credits Earned = 2</description>
        /// </item>
        /// </list>
        /// <para>Credits Disabled In Playlist: TotalCreditsEarned is zero because this playlist has credits 
        /// disabled.</para>
        /// <para>Player Did Not Finish: Credits are enabled in this playlist, but TotalCreditsEarned is zero because 
        /// the player did not finish the match.</para>
        /// <para>Credits Earned: Credits are enabled in this playlist and the player completed the match, so the 
        /// credits formula was successfully evaluated. The fields below provide the client with the values used in 
        /// the formula. Note: That if we used one or more default values, we still return "NormalResult". The fields 
        /// below will confirm the actual values used.</para>
        /// </summary>
        [JsonProperty(PropertyName = "Result")]
        public Enumeration.CreditsEarnedResultType Result { get; set; }

        /// <summary>
        /// The scalar applied to the credits earned based on the player's Spartan Rank.
        /// </summary>
        [JsonProperty(PropertyName = "SpartanRankModifier")]
        public double SpartanRankModifier { get; set; }

        /// <summary>
        /// The portion of credits earned due to the time the player played in the match.
        /// </summary>
        [JsonProperty(PropertyName = "TimePlayedAmount")]
        public double TimePlayedAmount { get; set; }

        /// <summary>
        /// The total number of credits the player earned from playing this match.
        /// </summary>
        [JsonProperty(PropertyName = "TotalCreditsEarned")]
        public int TotalCreditsEarned { get; set; }

        public bool Equals(CreditsEarned other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return BoostAmount == other.BoostAmount
                && PlayerRankAmount == other.PlayerRankAmount
                && Result == other.Result
                && SpartanRankModifier.Equals(other.SpartanRankModifier)
                && TimePlayedAmount.Equals(other.TimePlayedAmount)
                && TotalCreditsEarned == other.TotalCreditsEarned;
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

            if (obj.GetType() != typeof (CreditsEarned))
            {
                return false;
            }

            return Equals((CreditsEarned) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BoostAmount;
                hashCode = (hashCode*397) ^ PlayerRankAmount;
                hashCode = (hashCode*397) ^ (int) Result;
                hashCode = (hashCode*397) ^ SpartanRankModifier.GetHashCode();
                hashCode = (hashCode*397) ^ TimePlayedAmount.GetHashCode();
                hashCode = (hashCode*397) ^ TotalCreditsEarned;
                return hashCode;
            }
        }

        public static bool operator ==(CreditsEarned left, CreditsEarned right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreditsEarned left, CreditsEarned right)
        {
            return !Equals(left, right);
        }
    }
}