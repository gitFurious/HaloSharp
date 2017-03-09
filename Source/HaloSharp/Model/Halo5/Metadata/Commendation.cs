using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Halo5.Metadata.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Halo5.Metadata
{
    [Serializable]
    public class Commendation : IEquatable<Commendation>
    {
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "iconImageUrl")]
        public string IconImageUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "levels")]
        public List<Level> Levels { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "requiredLevels")]
        public List<RequiredLevel> RequiredLevels { get; set; }

        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.Halo5.CommendationType Type { get; set; }

        public bool Equals(Commendation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Category, other.Category)
                   && ContentId.Equals(other.ContentId) 
                   && string.Equals(Description, other.Description) 
                   && string.Equals(IconImageUrl, other.IconImageUrl) 
                   && Id.Equals(other.Id) 
                   && Levels.OrderBy(l => l.Id).SequenceEqual(other.Levels.OrderBy(l => l.Id))
                   && string.Equals(Name, other.Name) 
                   && RequiredLevels.OrderBy(rl => rl.Id).SequenceEqual(other.RequiredLevels.OrderBy(rl => rl.Id))
                   && Equals(Reward, other.Reward) 
                   && Type == other.Type;
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

            if (obj.GetType() != typeof (Commendation))
            {
                return false;
            }

            return Equals((Commendation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Category?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (IconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Levels?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (RequiredLevels?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Reward?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public static bool operator ==(Commendation left, Commendation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Commendation left, Commendation right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Level : IEquatable<Level>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        [JsonProperty(PropertyName = "threshold")]
        public int Threshold { get; set; }

        public bool Equals(Level other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ContentId.Equals(other.ContentId)
                   && Id.Equals(other.Id)
                   && Equals(Reward, other.Reward)
                   && Threshold == other.Threshold;
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

            if (obj.GetType() != typeof (Level))
            {
                return false;
            }

            return Equals((Level) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Reward?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Threshold;
                return hashCode;
            }
        }

        public static bool operator ==(Level left, Level right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Level left, Level right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class RequiredLevel : IEquatable<RequiredLevel>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "threshold")]
        public int Threshold { get; set; }

        public bool Equals(RequiredLevel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ContentId.Equals(other.ContentId)
                   && Id.Equals(other.Id)
                   && Threshold == other.Threshold;
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

            if (obj.GetType() != typeof (RequiredLevel))
            {
                return false;
            }

            return Equals((RequiredLevel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ Threshold;
                return hashCode;
            }
        }

        public static bool operator ==(RequiredLevel left, RequiredLevel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RequiredLevel left, RequiredLevel right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Category : IEquatable<Category>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "iconImageUrl")]
        public string IconImageUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }

        public bool Equals(Category other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ContentId.Equals(other.ContentId)
                   && string.Equals(IconImageUrl, other.IconImageUrl)
                   && Id.Equals(other.Id)
                   && string.Equals(Name, other.Name)
                   && Order == other.Order;
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

            if (obj.GetType() != typeof (Category))
            {
                return false;
            }

            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (IconImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Order;
                return hashCode;
            }
        }

        public static bool operator ==(Category left, Category right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Category left, Category right)
        {
            return !Equals(left, right);
        }
    }
}