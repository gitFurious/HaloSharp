using HaloSharp.Model.Stats.CarnageReport;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats.CarnageReport
{
    public class GetArenaMatchDetails : IQuery<ArenaMatch>
    {
        private string _matchId;

        public GetArenaMatchDetails ForMatchId(Guid matchId)
        {
            _matchId = matchId.ToString();
            return this;
        }

        public async Task<ArenaMatch> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<ArenaMatch>(MakeUrl());

            return match;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder($"stats/h5/arena/matches/{_matchId}");

            return builder.ToString();
        }
    }
}