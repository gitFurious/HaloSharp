using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.Playlist
{
    [Serializable]
    public class CardsFixedAtLevel : IEquatable<CardsFixedAtLevel>
    {
        [JsonIgnore]
        public int Unused { get; set; }

        public bool Equals(CardsFixedAtLevel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Unused == other.Unused;
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

            if (obj.GetType() != typeof(CardsFixedAtLevel))
            {
                return false;
            }

            return Equals((CardsFixedAtLevel) obj);
        }

        public override int GetHashCode()
        {
            return Unused;
        }

        public static bool operator ==(CardsFixedAtLevel left, CardsFixedAtLevel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardsFixedAtLevel left, CardsFixedAtLevel right)
        {
            return !Equals(left, right);
        }
    }
}