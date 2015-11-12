using HaloSharp.Model;
using HaloSharp.Model.Stats;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Stats
{
    public class GetMatches : IQuery<MatchSet>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        private string _player;

        public GetMatches ForPlayer(string gamertag)
        {
            _player = gamertag;
            return this;
        }

        public GetMatches InGameMode(Enumeration.GameMode gameMode)
        {
            _parameters["modes"] = gameMode.ToString();
            return this;
        }

        public GetMatches InGameModes(List<Enumeration.GameMode> gameModes)
        {
            _parameters["modes"] = string.Join(",", gameModes.Select(g => g.ToString()));
            return this;
        }

        public GetMatches Skip(int count)
        {
            _parameters["start"] = count.ToString();
            return this;
        }

        public GetMatches Take(int count)
        {
            _parameters["count"] = count.ToString();
            return this;
        }

        public async Task<MatchSet> ApplyTo(IHaloSession session)
        {
            var matchSet = await session.Get<MatchSet>(GetConstructedUri());

            return matchSet;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/players/{_player}/matches");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}