using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class GameVariant
    {
        public string Description { get; set; }
        public Guid? GameBaseVariantId { get; set; }
        public string IconUrl { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}