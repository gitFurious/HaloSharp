using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Difficulty
{
    [Serializable]
    public class Difficulty : IEquatable<Difficulty>
    {
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        public bool Equals(Difficulty other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id
                && Equals(DisplayInfo, other.DisplayInfo);
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

            if (obj.GetType() != typeof(Difficulty))
            {
                return false;
            }

            return Equals((Difficulty) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Difficulty left, Difficulty right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Difficulty left, Difficulty right)
        {
            return !Equals(left, right);
        }
    }
}