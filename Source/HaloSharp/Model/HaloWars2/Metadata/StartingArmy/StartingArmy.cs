using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.StartingArmy
{
    [Serializable]
    public class StartingArmy : IEquatable<StartingArmy>
    {
        [JsonProperty(PropertyName = "DisplayInfo")]
        public ContentItemTypeB<DisplayInfo.View> DisplayInfo { get; set; }

        [JsonProperty(PropertyName = "Cards")]
        public List<ContentItemTypeD> Cards { get; set; }

        public bool Equals(StartingArmy other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Cards.OrderBy(c => c.Id).SequenceEqual(other.Cards.OrderBy(c => c.Id))
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

            if (obj.GetType() != typeof(StartingArmy))
            {
                return false;
            }

            return Equals((StartingArmy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Cards?.GetHashCode() ?? 0)*397) ^ (DisplayInfo != null ? DisplayInfo.GetHashCode() : 0);
            }
        }

        public static bool operator ==(StartingArmy left, StartingArmy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StartingArmy left, StartingArmy right)
        {
            return !Equals(left, right);
        }
    }
}