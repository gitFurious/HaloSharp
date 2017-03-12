using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetSeasonSummary : Query<SeasonSummary>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/players/{_player}/stats/seasons/{_seasonId}");

        private readonly string _player;
        private readonly Guid _seasonId;

        public GetSeasonSummary(string player, Guid seasonId)
        {
            _player = player;
            _seasonId = seasonId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetSeasonSummary query requires a valid Gamertag to be set.");
            }

            if (!_seasonId.IsValid())
            {
                validationResult.Messages.Add("GetSeasonSummary query requires a valid Season Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
