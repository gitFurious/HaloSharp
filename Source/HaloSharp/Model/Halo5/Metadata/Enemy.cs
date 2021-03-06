﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Enemy : IEquatable<Enemy>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "faction")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.Faction Faction { get; set; }

        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        [JsonProperty(PropertyName = "largeIconImageUrl")]
        public string LargeIconImageUrl { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "smallIconImageUrl")]
        public string SmallIconImageUrl { get; set; }

        public bool Equals(Enemy other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Description, other.Description) 
                && Faction == other.Faction && Id == other.Id
                && string.Equals(LargeIconImageUrl, other.LargeIconImageUrl) 
                && string.Equals(Name, other.Name)
                && string.Equals(SmallIconImageUrl, other.SmallIconImageUrl)
                && ContentId.Equals(other.ContentId);
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

            if (obj.GetType() != typeof (Enemy))
            {
                return false;
            }

            return Equals((Enemy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Description?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (int) Faction;
                hashCode = (hashCode*397) ^ (int) Id;
                hashCode = (hashCode*397) ^ (LargeIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (SmallIconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Enemy left, Enemy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enemy left, Enemy right)
        {
            return !Equals(left, right);
        }
    }
}