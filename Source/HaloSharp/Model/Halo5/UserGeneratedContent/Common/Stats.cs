using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.UserGeneratedContent.Common
{
    [Serializable]
    public class Stats : IEquatable<Stats>
    {
        [JsonProperty(PropertyName = "BookmarkCount")]
        public int BookmarkCount { get; set; }

        [JsonProperty(PropertyName = "HasCallerBookmarked")]
        public bool HasCallerBookmarked { get; set; }

        public bool Equals(Stats other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return BookmarkCount == other.BookmarkCount 
                && HasCallerBookmarked == other.HasCallerBookmarked;
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

            if (obj.GetType() != typeof(Stats))
            {
                return false;
            }

            return Equals((Stats) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (BookmarkCount*397) ^ HasCallerBookmarked.GetHashCode();
            }
        }

        public static bool operator ==(Stats left, Stats right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stats left, Stats right)
        {
            return !Equals(left, right);
        }
    }
}