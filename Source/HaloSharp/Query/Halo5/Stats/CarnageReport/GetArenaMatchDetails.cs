using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using System;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetArenaMatchDetails : Query<ArenaMatch>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/arena/matches/{_matchId}");

        private readonly Guid _matchId;

        public GetArenaMatchDetails(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_matchId == default(Guid))
            {
                validationResult.Messages.Add("GetArenaMatchDetails query requires a Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}