using System;

namespace HaloSharp.Query.Halo5Forge.Stats.CarnageReport
{
    public class GetCustomMatchDetails : Halo5.Stats.CarnageReport.GetCustomMatchDetails
    {
        protected override string Path => $"stats/h5pc/custom/matches/{_matchId}";

        private readonly Guid _matchId;

        public GetCustomMatchDetails(Guid matchId) : base(matchId)
        {
            _matchId = matchId;
        }
    }
}