using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Common;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Lifetime.Common
{
    [Serializable]
    public class BaseServiceRecord : IEquatable<BaseServiceRecord>
    {
        [JsonProperty(PropertyName = "Links")]
        public Dictionary<string, Link> Links { get; set; }

        public bool Equals(BaseServiceRecord other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Links.OrderBy(l => l.Key).SequenceEqual(other.Links.OrderBy(l => l.Key));
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

            if (obj.GetType() != typeof (BaseServiceRecord))
            {
                return false;
            }

            return Equals((BaseServiceRecord) obj);
        }

        public override int GetHashCode()
        {
            return Links?.GetHashCode() ?? 0;
        }

        public static bool operator ==(BaseServiceRecord left, BaseServiceRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseServiceRecord left, BaseServiceRecord right)
        {
            return !Equals(left, right);
        }
    }
}