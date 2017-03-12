using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using System;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetMatchEvents : Query<MatchEventSummary>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/matches/{_matchId}/events");

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
                validationResult.Messages.Add("GetMatchEvents query requires a Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}