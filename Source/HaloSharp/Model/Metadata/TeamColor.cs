using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class TeamColor
    {
        public string Color { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}