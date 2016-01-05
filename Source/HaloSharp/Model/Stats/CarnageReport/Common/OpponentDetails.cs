using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    [Serializable]
    public class OpponentDetails : IEquatable<OpponentDetails>
    {
        /// <summary>
        /// The gamertag of the opponent that was killed/killed the player.
        /// </summary>
        [JsonProperty(PropertyName = "GamerTag")]
        public string GamerTag { get; set; }

        /// <summary>
        /// The number of times that opponent was killed/killed the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalKills")]
        public int TotalKills { get; set; }

        public bool Equals(OpponentDetails other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(GamerTag, other.GamerTag)
                && TotalKills == other.TotalKills;
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

            if (obj.GetType() != typeof (OpponentDetails))
            {
                return false;
            }

            return Equals((OpponentDetails) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((GamerTag?.GetHashCode() ?? 0)*397) ^ TotalKills;
            }
        }

        public static bool operator ==(OpponentDetails left, OpponentDetails right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpponentDetails left, OpponentDetails right)
        {
            return !Equals(left, right);
        }
    }
}