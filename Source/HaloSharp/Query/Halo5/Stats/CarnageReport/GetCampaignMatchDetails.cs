using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using System;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetCampaignMatchDetails : Query<CampaignMatch>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/campaign/matches/{_matchId}");

        private readonly Guid _matchId;

        public GetCampaignMatchDetails(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_matchId == default(Guid))
            {
                validationResult.Messages.Add("GetCampaignMatchDetails query requires a Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}