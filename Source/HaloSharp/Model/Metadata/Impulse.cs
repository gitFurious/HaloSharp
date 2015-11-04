using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class Impulse
    {
        public uint Id { get; set; }

        // Internal use.
        public string InternalName { get; set; }
        //public string ContentId { get; set; }
    }
}