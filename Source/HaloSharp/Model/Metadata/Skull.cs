using System;

namespace HaloSharp.Model.Metadata
{
    public class Skull
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public Guid? MissionId { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}