using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CampaignLevel.DisplayInfo
{
    [Serializable]
    public class View : Metadata.DisplayInfo.View, IEquatable<View>
    {
        [JsonProperty(PropertyName = "HW2CampaignLevelDisplayInfo")]
        public Metadata.DisplayInfo.DisplayInfo DisplayInfo { get; set; }

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
                return (base.GetHashCode()*397) ^ (DisplayInfo?.GetHashCode() ?? 0);
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