using HaloSharp.Model.Stats.CarnageReport;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats.CarnageReport
{
    public class GetWarzoneMatchDetails : IQuery<WarzoneMatch>
    {
        private string _matchId;

        public GetWarzoneMatchDetails ForMatchId(Guid matchId)
        {
            _matchId = matchId.ToString();
            return this;
        }

        public async Task<WarzoneMatch> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<WarzoneMatch>(MakeUrl());

            return match;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder($"stats/h5/warzone/matches/{_matchId}");

            return builder.ToString();
        }
    }
}