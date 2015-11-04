using HaloSharp.Model.Metadata.Common;
using System;

namespace HaloSharp.Model.Metadata
{
    [Serializable]
    public class SpartanRank
    {
        public int Id { get; set; }
        public Reward Reward { get; set; }
        public int StartXp { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}