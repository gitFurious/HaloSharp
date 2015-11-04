using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Metadata.Common
{
    [Serializable]
    public class Reward
    {
        public Guid Id { get; set; }
        public List<RequisitionPack> RequisitionPacks { get; set; }
        public int Xp { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}