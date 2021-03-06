using System;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.HaloWars2.Stats;
using System.Collections.Generic;
using HaloSharp.Exception;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.HaloWars2.Stats
{
    public class GetMatchHistory : Query<MatchSet<PlayerMatch>>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/players/{_player}/matches", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string MatchTypeParameter = "matchType";
        private const string StartParameter = "start";
        private const string CountParameter = "count";

        private readonly string _player;

        public GetMatchHistory(string player)
        {
            _player = player;
        }

        public GetMatchHistory ForMatchType(Enumeration.HaloWars2.MatchType matchType)
        {
            _parameters[MatchTypeParameter] = matchType.ToString();

            return this;
        }

        public GetMatchHistory Skip(int count)
        {
            _parameters[StartParameter] = count.ToString();

            return this;
        }

        public GetMatchHistory Take(int count)
        {
            _parameters[CountParameter] = count.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMatchHistory query requires a valid Gamertag (Player) to be set.");
            }

            if (_parameters.ContainsKey(CountParameter))
            {
                int take;
                var parsed = int.TryParse(_parameters[CountParameter], out take);

                if (!parsed || !take.IsValidTake())
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter '{CountParameter}' is invalid: {take}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
