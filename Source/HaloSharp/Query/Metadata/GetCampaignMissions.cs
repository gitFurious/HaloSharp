using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetCampaignMissions : IQuery<List<CampaignMission>>
    {
        private const string CacheKey = "CampaignMissions";

        private bool _useCache = true;

        public GetCampaignMissions SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<CampaignMission>> ApplyTo(IHaloSession session)
        {
            var campaignMissions = _useCache 
                ? Cache.Get<List<CampaignMission>>(CacheKey) 
                : null;

            if (campaignMissions != null)
            {
                return campaignMissions;
            }

            campaignMissions = await session.Get<List<CampaignMission>>(GetConstructedUri());

            Cache.Add(CacheKey, campaignMissions);

            return campaignMissions;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/campaign-missions");

            return builder.ToString();
        }
    }
}
