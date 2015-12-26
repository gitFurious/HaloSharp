using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class CampaignMission : IEquatable<CampaignMission>
    {
        [JsonProperty(PropertyName = "contentId")]
        public Guid ContentId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "missionNumber")]
        public int MissionNumber { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.CampaignMissionType Type { get; set; }

        public bool Equals(CampaignMission other)
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
                   && string.Equals(Description, other.Description)
                   && Id.Equals(other.Id)
                   && string.Equals(ImageUrl, other.ImageUrl)
                   && MissionNumber == other.MissionNumber
                   && string.Equals(Name, other.Name)
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

            if (obj.GetType() != typeof (CampaignMission))
            {
                return false;
            }

            return Equals((CampaignMission) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ContentId.GetHashCode();
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Id.GetHashCode();
                hashCode = (hashCode*397) ^ (ImageUrl?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ MissionNumber;
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }

        public static bool operator ==(CampaignMission left, CampaignMission right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignMission left, CampaignMission right)
        {
            return !Equals(left, right);
        }
    }
}