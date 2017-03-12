using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using System;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetCustomMatchDetails : Query<CustomMatch>
    {
        protected virtual string Path => $"stats/h5/custom/matches/{_matchId}";

        public override string Uri => HaloUriBuilder.Build(Path);

        private readonly Guid _matchId;

        public GetCustomMatchDetails(Guid matchId)
        {
            _matchId = matchId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_matchId == default(Guid))
            {
                validationResult.Messages.Add("GetCustomMatchDetails query requires a Match Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}