using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Identity : IEquatable<Identity>
    {
        /// <summary>
        /// The player's gamertag.
        /// </summary>
        [JsonProperty(PropertyName = "Gamertag")]
        public string Gamertag { get; set; }

        /// <summary>
        /// Internal use only. This will always be null.
        /// </summary>
        [JsonProperty(PropertyName = "Xuid")]
        public object Xuid { get; set; }

        public bool Equals(Identity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Gamertag, other.Gamertag)
                && Equals(Xuid, other.Xuid);
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

            if (obj.GetType() != typeof (Identity))
            {
                return false;
            }

            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Gamertag?.GetHashCode() ?? 0)*397) ^ (Xuid?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(Identity left, Identity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identity left, Identity right)
        {
            return !Equals(left, right);
        }
    }
}