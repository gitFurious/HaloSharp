using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.Lifetime;

namespace HaloSharp.Query.Stats.Lifetime
{
    public class GetCampaignServiceRecord : IQuery<CampaignServiceRecord>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        public GetCampaignServiceRecord ForPlayer(string gamertag)
        {
            _parameters["players"] = gamertag;
            return this;
        }

        public GetCampaignServiceRecord ForPlayers(List<string> gamertags)
        {
            _parameters["players"] = string.Join(",", gamertags);
            return this;
        }

        public async Task<CampaignServiceRecord> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<CampaignServiceRecord>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/campaign");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}