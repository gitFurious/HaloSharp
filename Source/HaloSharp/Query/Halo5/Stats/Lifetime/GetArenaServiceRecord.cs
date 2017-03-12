using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    public class GetArenaServiceRecord : Query<ArenaServiceRecord>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/servicerecords/arena", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string PlayersParameter = "players";
        private const string SeasonIdParameter = "seasonId";

        public GetArenaServiceRecord(string gamertag)
        {
            _parameters[PlayersParameter] = gamertag;
        }

        public GetArenaServiceRecord(IEnumerable<string> gamertags)
        {
            _parameters[PlayersParameter] = string.Join(",", gamertags);
        }

        public GetArenaServiceRecord ForSeasonId(Guid seasonId)
        {
            _parameters["seasonId"] = seasonId.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            var players = _parameters[PlayersParameter].Split(',');

            foreach (var player in players)
            {
                if (!player.IsValidGamertag())
                {
                    validationResult.Messages.Add("GetArenaServiceRecord query requires valid Gamertags to be set.");
                }
            }

            if (_parameters.ContainsKey(SeasonIdParameter))
            {
                Guid seasonId;
                var parsed = Guid.TryParse(_parameters[SeasonIdParameter], out seasonId);

                if (!parsed || seasonId == default(Guid))
                {
                    validationResult.Messages.Add($"GetArenaServiceRecord optional parameter '{SeasonIdParameter}' is invalid: {seasonId}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}