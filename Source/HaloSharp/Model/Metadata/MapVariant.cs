using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class MapVariant
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public Guid? MapId { get; set; }
        public string MapImageUrl { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}