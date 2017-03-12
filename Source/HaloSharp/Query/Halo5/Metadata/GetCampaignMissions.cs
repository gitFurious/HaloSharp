using HaloSharp.Model.Halo5.Metadata;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetCampaignMissions : Query<List<CampaignMission>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/h5/metadata/campaign-missions");
    }
}