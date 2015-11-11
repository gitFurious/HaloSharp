using HaloSharp.Model.Metadata.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Commendation : IEquatable<Commendation>
    {
        public Category Category { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string IconImageUrl { get; set; }
        public Guid Id { get; set; }
        public List<Level> Levels { get; set; }
        public string Name { get; set; }
        public List<RequiredLevel> RequiredLevels { get; set; }
        public Reward Reward { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.CommendationType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

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
                && string.Equals(Description, other.Description)
                && Enabled == other.Enabled
                && string.Equals(IconImageUrl, other.IconImageUrl)
                && Id.Equals(other.Id)
                && Levels.OrderBy(l => l.Id).SequenceEqual(Levels.OrderBy(l => l.Id))
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
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Enabled.GetHashCode();
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
        public Guid Id { get; set; }
        public Reward Reward { get; set; }
        public int Threshold { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

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

            return Id.Equals(other.Id)
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
                var hashCode = Id.GetHashCode();
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
        public Guid Id { get; set; }
        public int Threshold { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }

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

            return Id.Equals(other.Id)
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
                return (Id.GetHashCode()*397) ^ Threshold;
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
        public string IconImageUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        public int Order { get; set; }
        //public Guid ContentId { get; set; }

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

            return string.Equals(IconImageUrl, other.IconImageUrl)
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
                int hashCode = IconImageUrl?.GetHashCode() ?? 0;
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