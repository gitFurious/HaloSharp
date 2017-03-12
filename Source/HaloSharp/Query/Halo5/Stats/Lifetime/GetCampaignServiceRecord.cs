using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    public class GetCampaignServiceRecord : Query<CampaignServiceRecord>
    {
        public override string Uri => HaloUriBuilder.Build("stats/h5/servicerecords/campaign", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string PlayersParameter = "players";

        public GetCampaignServiceRecord(string gamertag)
        {
            _parameters[PlayersParameter] = gamertag;
        }

        public GetCampaignServiceRecord(IEnumerable<string> gamertags)
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
                    validationResult.Messages.Add("GetCampaignServiceRecord query requires valid Gamertags to be set.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}