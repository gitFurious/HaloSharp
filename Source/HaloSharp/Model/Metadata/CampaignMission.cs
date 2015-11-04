using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class CampaignMission
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public int MissionNumber { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Enumeration.CampaignMissionType Type { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}