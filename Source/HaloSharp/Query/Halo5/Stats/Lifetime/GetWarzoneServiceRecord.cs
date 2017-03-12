using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    public class GetWarzoneServiceRecord : Query<WarzoneServiceRecord>
    {
        public override string Uri => HaloUriBuilder.Build("stats/h5/servicerecords/warzone", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string PlayersParameter = "players";

        public GetWarzoneServiceRecord(string gamertag)
        {
            _parameters[PlayersParameter] = gamertag;
        }

        public GetWarzoneServiceRecord(IEnumerable<string> gamertags)
        {
            _parameters[PlayersParameter] = string.Join(",", gamertags);
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            var players = _parameters[PlayersParameter].Split(',');

            foreach (var player in players)
            {
                if (!player.IsValidGamertag())
                {
                    validationResult.Messages.Add("GetWarzoneServiceRecord query requires valid Gamertags to be set.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
       
    }
}