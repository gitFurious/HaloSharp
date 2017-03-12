using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System.Collections.Generic;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetExperienceSummary : Query<ExperienceSummaryResultSet>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/xp", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string PlayersParameter = "players";

        public GetExperienceSummary(string player)
        {
            _parameters[PlayersParameter] = player;
        }

        public GetExperienceSummary(IEnumerable<string> players)
        {
            _parameters[PlayersParameter] = string.Join(",", players);
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            var players = _parameters[PlayersParameter].Split(',');

            foreach (var player in players)
            {
                if (!player.IsValidGamertag())
                {
                    validationResult.Messages.Add("GetExperienceSummary query requires a valid Gamertag to be set.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
