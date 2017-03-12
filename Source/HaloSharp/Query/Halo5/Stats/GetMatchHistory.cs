using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Validation.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Query.Halo5.Stats
{
    public class GetMatchHistory : Query<MatchSet<PlayerMatch>>
    {
        protected virtual string Path => $"stats/h5/players/{_player}/matches";

        public override string Uri => HaloUriBuilder.Build(Path, _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string ModesParameter = "modes";
        private const string StartParameter = "start";
        private const string CountParameter = "count";

        private readonly string _player;

        public GetMatchHistory(string gamertag)
        {
            _player = gamertag;
        }

        public GetMatchHistory InGameMode(Enumeration.Halo5.GameMode gameMode)
        {
            _parameters[ModesParameter] = gameMode.ToString();

            return this;
        }

        public GetMatchHistory InGameModes(IEnumerable<Enumeration.Halo5.GameMode> gameModes)
        {
            _parameters[ModesParameter] = string.Join(",", gameModes.Select(g => g.ToString()));

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
                validationResult.Messages.Add("GetMatchHistory query requires a valid Gamertag to be set.");
            }

            if (_parameters.ContainsKey(ModesParameter))
            {
                var modes = _parameters[ModesParameter].Split(',');

                foreach (var mode in modes)
                {
                    var defined = Enum.IsDefined(typeof(Enumeration.Halo5.GameMode), mode);

                    if (!defined)
                    {
                        validationResult.Messages.Add($"GetMatchHistory optional parameter '{ModesParameter}' is invalid: {mode}.");
                    }
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