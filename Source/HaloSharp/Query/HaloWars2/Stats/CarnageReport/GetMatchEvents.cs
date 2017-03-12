using HaloSharp.Model.HaloWars2.Stats.CarnageReport;
using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.HaloWars2.Stats.CarnageReport
{
    public class GetMatchEvents : Query<MatchEventSummary>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/matches/{_matchId}/events");

        private readonly Guid _matchId;

        public GetMatchEvents(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_matchId.IsValid())
            {
                validationResult.Messages.Add("GetMatchEvents query requires a valid Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
