using HaloSharp.Model.Stats.CarnageReport;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats.CarnageReport
{
    public class GetCustomMatchDetails : IQuery<CustomMatch>
    {
        private string _matchId;

        public GetCustomMatchDetails ForMatchId(Guid matchId)
        {
            _matchId = matchId.ToString();
            return this;
        }

        public async Task<CustomMatch> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<CustomMatch>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/custom/matches/{_matchId}");

            return builder.ToString();
        }
    }
}