using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.PlaylistEntry
{
    [Serializable]
    public class PlaylistEntry : IEquatable<PlaylistEntry>
    {
        [JsonProperty(PropertyName = "Weight")]
        public int Weight { get; set; }

        [JsonProperty(PropertyName = "VotingSlot")]
        public int VotingSlot { get; set; }

        [JsonProperty(PropertyName = "GameMode")]
        public string GameMode { get; set; }

        [JsonProperty(PropertyName = "Map")]
        public List<ContentItemTypeB<Map.View>> Maps { get; set; }

        [JsonProperty(PropertyName = "MaxPlayers")]
        public int MaxPlayers { get; set; }

        public bool Equals(PlaylistEntry other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(GameMode, other.GameMode)
                && Maps.OrderBy(m => m.Id).SequenceEqual(other.Maps.OrderBy(m => m.Id))
                && MaxPlayers == other.MaxPlayers
                && VotingSlot == other.VotingSlot
                && Weight == other.Weight;
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

            if (obj.GetType() != typeof(PlaylistEntry))
            {
                return false;
            }

            return Equals((PlaylistEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GameMode?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Maps?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MaxPlayers;
                hashCode = (hashCode*397) ^ VotingSlot;
                hashCode = (hashCode*397) ^ Weight;
                return hashCode;
            }
        }

        public static bool operator ==(PlaylistEntry left, PlaylistEntry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PlaylistEntry left, PlaylistEntry right)
        {
            return !Equals(left, right);
        }
    }
}