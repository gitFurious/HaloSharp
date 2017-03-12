using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CardKeyword
{
    [Serializable]
    public class CardKeyword : IEquatable<CardKeyword>
    {
        [JsonProperty(PropertyName = "Keyword")]
        public string Keyword { get; set; }

        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        public bool Equals(CardKeyword other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(Keyword, other.Keyword)
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

            if (obj.GetType() != typeof(CardKeyword))
            {
                return false;
            }

            return Equals((CardKeyword) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Keyword?.GetHashCode() ?? 0)*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CardKeyword left, CardKeyword right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardKeyword left, CardKeyword right)
        {
            return !Equals(left, right);
        }
    }
}