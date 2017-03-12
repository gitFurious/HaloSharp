using HaloSharp.Model.HaloWars2.Stats.CarnageReport;
using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.HaloWars2.Stats.CarnageReport
{
    public class GetMatchDetails : Query<Match>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/matches/{_matchId}");

        private readonly Guid _matchId;

        public GetMatchDetails(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_matchId.IsValid())
            {
                validationResult.Messages.Add("GetMatchDetails query requires a valid Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
