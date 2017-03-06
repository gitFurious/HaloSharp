using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Playlist
{
    [Serializable]
    public class Playlist : IEquatable<Playlist>
    {
        [JsonProperty(PropertyName = "ComputerDifficulty")]
        public ContentItemTypeB<Difficulty.View> ComputerDifficulty { get; set; }

        [JsonProperty(PropertyName = "CardsFixedAtLevel")]
        public CardsFixedAtLevel CardsFixedAtLevel { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public ContentItemTypeB<Image.View> Image { get; set; }

        [JsonProperty(PropertyName = "ThumbnailImage")]
        public ContentItemTypeB<Image.View> ThumbnailImage { get; set; }

        [JsonProperty(PropertyName = "MaxPartySize")]
        public int MaxPartySize { get; set; }

        [JsonProperty(PropertyName = "MinPartySize")]
        public int MinPartySize { get; set; }

        [JsonProperty(PropertyName = "UsesBanRules")]
        public bool UsesBanRules { get; set; }

        [JsonProperty(PropertyName = "MatchTicketTimeoutDurationSeconds")]
        public int MatchTicketTimeoutDurationSeconds { get; set; }

        [JsonProperty(PropertyName = "MpsdHopperName")]
        public string MpsdHopperName { get; set; }

        [JsonProperty(PropertyName = "MpsdHopperStatName")]
        public string MpsdHopperStatName { get; set; }

        [JsonProperty(PropertyName = "Voting")]
        public bool Voting { get; set; }

        [JsonProperty(PropertyName = "PlaylistEntries")]
        public List<ContentItemTypeB<PlaylistEntry.View>> PlaylistEntries { get; set; }

        [JsonProperty(PropertyName = "MaxPlayerCount")]
        public int MaxPlayerCount { get; set; }

        [JsonProperty(PropertyName = "MinPlayerCount")]
        public int MinPlayerCount { get; set; }

        [JsonProperty(PropertyName = "IsTeamGamePlaylist")]
        public bool IsTeamGamePlaylist { get; set; }

        [JsonProperty(PropertyName = "LonelyPartyUsesWildcard")]
        public bool LonelyPartyUsesWildcard { get; set; }

        [JsonProperty(PropertyName = "IsNew")]
        public bool IsNew { get; set; }

        [JsonProperty(PropertyName = "Hide")]
        public bool Hide { get; set; }

        [JsonProperty(PropertyName = "IsQuickmatchPlaylist")]
        public bool IsQuickmatchPlaylist { get; set; }

        [JsonProperty(PropertyName = "StatsClassification")]
        public string StatsClassification { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<Displayinfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "TargetPlatform")]
        public string TargetPlatform { get; set; }

        public bool Equals(Playlist other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(CardsFixedAtLevel, other.CardsFixedAtLevel)
                && Equals(ComputerDifficulty, other.ComputerDifficulty)
                && Equals(DisplayInfo, other.DisplayInfo)
                && Hide == other.Hide
                && string.Equals(Id, other.Id)
                && Equals(Image, other.Image)
                && IsNew == other.IsNew
                && IsQuickmatchPlaylist == other.IsQuickmatchPlaylist
                && IsTeamGamePlaylist == other.IsTeamGamePlaylist
                && LonelyPartyUsesWildcard == other.LonelyPartyUsesWildcard
                && MatchTicketTimeoutDurationSeconds == other.MatchTicketTimeoutDurationSeconds
                && MaxPartySize == other.MaxPartySize
                && MaxPlayerCount == other.MaxPlayerCount
                && MinPartySize == other.MinPartySize
                && MinPlayerCount == other.MinPlayerCount
                && string.Equals(MpsdHopperName, other.MpsdHopperName)
                && string.Equals(MpsdHopperStatName, other.MpsdHopperStatName)
                && PlaylistEntries.OrderBy(pe => pe.Id).SequenceEqual(other.PlaylistEntries.OrderBy(pe => pe.Id))
                && string.Equals(StatsClassification, other.StatsClassification)
                && string.Equals(TargetPlatform, other.TargetPlatform)
                && Equals(ThumbnailImage, other.ThumbnailImage)
                && UsesBanRules == other.UsesBanRules
                && Voting == other.Voting;
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

            if (obj.GetType() != typeof(Playlist))
            {
                return false;
            }

            return Equals((Playlist) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CardsFixedAtLevel?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (ComputerDifficulty != null ? ComputerDifficulty.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Hide.GetHashCode();
                hashCode = (hashCode*397) ^ (Id?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Image != null ? Image.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsNew.GetHashCode();
                hashCode = (hashCode*397) ^ IsQuickmatchPlaylist.GetHashCode();
                hashCode = (hashCode*397) ^ IsTeamGamePlaylist.GetHashCode();
                hashCode = (hashCode*397) ^ LonelyPartyUsesWildcard.GetHashCode();
                hashCode = (hashCode*397) ^ MatchTicketTimeoutDurationSeconds;
                hashCode = (hashCode*397) ^ MaxPartySize;
                hashCode = (hashCode*397) ^ MaxPlayerCount;
                hashCode = (hashCode*397) ^ MinPartySize;
                hashCode = (hashCode*397) ^ MinPlayerCount;
                hashCode = (hashCode*397) ^ (MpsdHopperName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MpsdHopperStatName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (PlaylistEntries?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (StatsClassification?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (TargetPlatform?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (ThumbnailImage != null ? ThumbnailImage.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UsesBanRules.GetHashCode();
                hashCode = (hashCode*397) ^ Voting.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Playlist left, Playlist right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Playlist left, Playlist right)
        {
            return !Equals(left, right);
        }
    }
}