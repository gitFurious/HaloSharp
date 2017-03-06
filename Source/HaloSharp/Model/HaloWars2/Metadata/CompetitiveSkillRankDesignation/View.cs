using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Metadata.CompetitiveSkillRankDesignation
{
    [Serializable]
    public class View : Metadata.View, IEquatable<View>
    {
        [JsonProperty(PropertyName = "HW2CsrDesignation")]
        public CompetitiveSkillRankDesignation CompetitiveSkillRankDesignation { get; set; }

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
                && Equals(CompetitiveSkillRankDesignation, other.CompetitiveSkillRankDesignation);
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
                return (base.GetHashCode()*397) ^ (CompetitiveSkillRankDesignation != null ? CompetitiveSkillRankDesignation.GetHashCode() : 0);
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