using HaloSharp.Model.Metadata.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Metadata
{
    public class Commendation
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
    }

    public class Level
    {
        public Guid Id { get; set; }
        public Reward Reward { get; set; }
        public int Threshold { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }

    public class RequiredLevel
    {
        public Guid Id { get; set; }
        public int Threshold { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }

    public class Category
    {
        public string IconImageUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        public int Order { get; set; }
        //public Guid ContentId { get; set; }
    }
}