using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetSummary : Query<PlayerSummary>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/players/{_player}/stats");

        private readonly string _player;

        public GetSummary(string player)
        {
            _player = player;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetSummary query requires a valid Gamertag to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
