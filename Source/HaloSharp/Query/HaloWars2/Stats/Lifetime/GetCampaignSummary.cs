using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.HaloWars2.Stats.Lifetime;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetCampaignSummary : IQuery<CampaignSummary>
    {
        internal readonly string Player;

        private bool _useCache = true;

        public GetCampaignSummary(string player)
        {
            Player = player;
        }

        public GetCampaignSummary SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<CampaignSummary> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<CampaignSummary>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<CampaignSummary>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            return $"stats/hw2/players/{Player}/campaign-progress";
        }
    }
}
