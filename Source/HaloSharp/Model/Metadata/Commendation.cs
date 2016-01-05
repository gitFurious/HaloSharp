using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Model.Metadata.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Commendation : IEquatable<Commendation>
    {
        /// <summary>
        /// Information about how this commendation should be categorized when shown to users.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }

        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// A localized description, suitable for display to users.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// An image that is used as the icon for this commendation.
        /// </summary>
        [JsonProperty(PropertyName = "iconImageUrl")]
        public string IconImageUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this commendation.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// One or more levels that model what a player must do to earn rewards and complete the commendation.
        /// </summary>
        [JsonProperty(PropertyName = "levels")]
        public List<Level> Levels { get; set; }

        /// <summary>
        /// A localized name for the commendation, suitable for display to users. The text is title cased. 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// For meta commendations, the commendation is considered "completed" when all required levels have been 
        /// "completed". This list contains one or more Level Ids from other commendations.For progressive 
        /// commendations, this list is empty.
        /// </summary>
        [JsonProperty(PropertyName = "requiredLevels")]
        public List<RequiredLevel> RequiredLevels { get; set; }

        /// <summary>
        /// The reward the player will receive for earning this commendation.
        /// </summary>
        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        /// <summary>
        /// Indicates the type of commendation. This is one of the two following options:
        /// <list type="bullet">
        /// <item>
        /// <description>Progressive</description>
        /// </item>
        /// <item>
        /// <description>Meta</description>
        /// </item>
        /// <item>
        /// <description>Daily</description>
        /// </item>
        /// </list>
        /// Progressive commendations have a series of increasingly difficult thresholds(levels) a player must cross to 
        /// receive increasingly greater rewards.Meta commendations are unlocked when a player has completed one or 
        /// more other commendation levels.We model this by giving meta commendations one level with dependencies 
        /// rather than a threshold.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.CommendationType Type { get; set; }

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
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this commendation level.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The reward the player will receive for earning this level.
        /// </summary>
        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        /// <summary>
        /// For progressive commendations this indicates the threshold that the player must meet or exceed to consider the commendation level "completed". For meta commendations, this value is always zero.
        /// </summary>
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
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// The ID of the commendation level that must be met in order to consider the level requirement met.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The threshold that the player must meet or exceed in order to consider the level requirement met.
        /// </summary>
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
        /// <summary>
        /// Internal use only. Do not use.
        /// </summary>
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        /// <summary>
        /// An image that is used as the icon for this category.
        /// </summary>
        [JsonProperty(PropertyName = "iconImageUrl")]
        public string IconImageUrl { get; set; }

        /// <summary>
        /// The ID that uniquely identifies this category.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// A localized name for the category, suitable for display to users. The text is title cased.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Internal use. The order in which the category should be displayed relative to other categories. The lower 
        /// the value, the more important the category - more important categories should be shownbefore or ahead of 
        /// less important categories.
        /// </summary>
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