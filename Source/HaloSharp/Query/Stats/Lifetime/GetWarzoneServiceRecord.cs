using HaloSharp.Model.Stats.Lifetime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats.Lifetime
{
    public class GetWarzoneServiceRecord : IQuery<WarzoneServiceRecord>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        public GetWarzoneServiceRecord ForPlayer(string gamertag)
        {
            _parameters["players"] = gamertag;
            return this;
        }

        public GetWarzoneServiceRecord ForPlayers(List<string> gamertags)
        {
            _parameters["players"] = string.Join(",", gamertags);
            return this;
        }

        public async Task<WarzoneServiceRecord> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<WarzoneServiceRecord>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/warzone");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}