using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CardKeyword
{
    [Serializable]
    public class View : Metadata.View, IEquatable<View>
    {
        [JsonProperty(PropertyName = "Autoroute")]
        public string Autoroute { get; set; }

        [JsonProperty(PropertyName = "HW2CardKeyword")]
        public CardKeyword CardKeyword { get; set; }

        public bool Equals(View other)
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
                && string.Equals(Autoroute, other.Autoroute)
                && Equals(CardKeyword, other.CardKeyword);
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

            if (obj.GetType() != typeof(View))
            {
                return false;
            }

            return Equals((View) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (Autoroute?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (CardKeyword != null ? CardKeyword.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(View left, View right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(View left, View right)
        {
            return !Equals(left, right);
        }
    }
}