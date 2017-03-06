using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Validation.HaloWars2.Stats.Player;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.HaloWars2.Stats.Player
{
    public class GetMatchHistory : IQuery<MatchSet<PlayerMatch>>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly string Player;

        private bool _useCache = true;

        public GetMatchHistory(string player)
        {
            Player = player;
        }

        public GetMatchHistory ForMatchType(Enumeration.HaloWars2.MatchType matchType)
        {
            Parameters["matchType"] = matchType.ToString();

            return this;
        }

        public GetMatchHistory Skip(int count)
        {
            Parameters["start"] = count.ToString();

            return this;
        }

        public GetMatchHistory Take(int count)
        {
            Parameters["count"] = count.ToString();

            return this;
        }

        public GetMatchHistory SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<MatchSet<PlayerMatch>> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<MatchSet<PlayerMatch>>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<MatchSet<PlayerMatch>>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/hw2/players/{Player}/matches");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}
