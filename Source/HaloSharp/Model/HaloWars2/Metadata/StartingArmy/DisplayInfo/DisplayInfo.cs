using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.StartingArmy.DisplayInfo
{
    [Serializable]
    public class DisplayInfo : IEquatable<DisplayInfo>
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        public bool Equals(DisplayInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name);
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

            if (obj.GetType() != typeof(DisplayInfo))
            {
                return false;
            }

            return Equals((DisplayInfo) obj);
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

        public static bool operator ==(DisplayInfo left, DisplayInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DisplayInfo left, DisplayInfo right)
        {
            return !Equals(left, right);
        }
    }
}