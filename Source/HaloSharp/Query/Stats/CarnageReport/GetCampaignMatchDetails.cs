using HaloSharp.Model.Stats.CarnageReport;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats.CarnageReport
{
    public class GetCampaignMatchDetails : IQuery<CampaignMatch>
    {
        private string _matchId;

        public GetCampaignMatchDetails ForMatchId(Guid matchId)
        {
            _matchId = matchId.ToString();
            return this;
        }

        public async Task<CampaignMatch> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<CampaignMatch>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/campaign/matches/{_matchId}");

            return builder.ToString();
        }
    }
}