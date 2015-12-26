using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.CarnageReport;

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
            var match = await session.Get<WarzoneMatch>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/warzone/matches/{_matchId}");

            return builder.ToString();
        }
    }
}