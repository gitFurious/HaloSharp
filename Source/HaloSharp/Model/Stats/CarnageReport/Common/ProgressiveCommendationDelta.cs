using System;

namespace HaloSharp.Model.Stats.CarnageReport.Common
{
    public class ProgressiveCommendationDelta
    {
        public Guid Id { get; set; }
        public int PreviousProgress { get; set; }
        public int Progress { get; set; }
    }
}