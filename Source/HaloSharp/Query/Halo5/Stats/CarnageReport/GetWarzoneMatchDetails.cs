using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using System;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetWarzoneMatchDetails : Query<WarzoneMatch>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/warzone/matches/{_matchId}");

        private readonly Guid _matchId;

        public GetWarzoneMatchDetails(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_matchId.IsValid())
            {
                validationResult.Messages.Add("GetWarzoneMatchDetails query requires a Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}