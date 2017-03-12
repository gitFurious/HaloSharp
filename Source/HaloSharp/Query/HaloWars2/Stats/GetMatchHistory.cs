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

            if (_parameters.ContainsKey(MatchTypeParameter))
            {
                var matchType = _parameters[MatchTypeParameter];

                var defined = Enum.IsDefined(typeof(Enumeration.HaloWars2.MatchType), matchType);

                if (!defined)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter '{MatchTypeParameter}' is invalid: {matchType}.");
                }
            }

            if (_parameters.ContainsKey(StartParameter))
            {
                int start;
                var parsed = int.TryParse(_parameters[StartParameter], out start);

                if (!parsed || start < 0)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter '{StartParameter}' is invalid: {start}.");
                }
            }

            if (_parameters.ContainsKey(CountParameter))
            {
                int count;
                var parsed = int.TryParse(_parameters[CountParameter], out count);

                if (!parsed || count < 1 || count > 25)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter '{CountParameter}' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
