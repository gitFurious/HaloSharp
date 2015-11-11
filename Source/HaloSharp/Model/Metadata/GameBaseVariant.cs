using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class GameBaseVariant : IEquatable<GameBaseVariant>
    {
        public string IconUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(ItemConverterType = typeof (StringEnumConverter))]
        public List<Enumeration.GameMode> SupportedGameModes { get; set; }

        // Internal use.
        public string InternalName { get; set; }
        //public Guid ContentId { get; set; }

        public bool Equals(GameBaseVariant other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(IconUrl, other.IconUrl)
                   && Id.Equals(other.Id)
                   && string.Equals(InternalName, other.InternalName)
                   && string.Equals(Name, other.Name)
                   && SupportedGameModes.OrderBy(sgm => sgm.ToString()) .SequenceEqual(other.SupportedGameModes.OrderBy(sgm => sgm.ToString()));
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

            if (obj.GetType() != typeof (GameBaseVariant))
            {
                return false;
            }

            return Equals((GameBaseVariant) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IconUrl?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (InternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SupportedGameModes?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(GameBaseVariant left, GameBaseVariant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameBaseVariant left, GameBaseVariant right)
        {
            return !Equals(left, right);
        }
    }
}