using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetCampaignMatchDetails : IQuery<CampaignMatch>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetCampaignMatchDetails(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetCampaignMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<CampaignMatch> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var match = _useCache
                ? Cache.Get<CampaignMatch>(uri)
                : null;

            if (match == null)
            {
                match = await session.Get<CampaignMatch>(uri);

                Cache.AddStats(uri, match);
            }

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/campaign/matches/{MatchId}");

            return builder.ToString();
        }
    }
}