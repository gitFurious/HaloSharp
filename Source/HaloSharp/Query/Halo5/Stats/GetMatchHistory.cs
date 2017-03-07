using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Validation.Halo5.Stats;

namespace HaloSharp.Query.Halo5.Stats
{
    public class GetMatchHistory : IQuery<MatchSet<PlayerMatch>>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly string Player;

        private bool _useCache = true;

        public GetMatchHistory(string gamertag)
        {
            Player = gamertag;
        }

        public GetMatchHistory SkipCache()
        {
            _useCache = false;

            return this;
        }

        public GetMatchHistory InGameMode(Enumeration.Halo5.GameMode gameMode)
        {
            Parameters["modes"] = gameMode.ToString();

            return this;
        }

        public GetMatchHistory InGameModes(List<Enumeration.Halo5.GameMode> gameModes)
        {
            Parameters["modes"] = string.Join(",", gameModes.Select(g => g.ToString()));

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

        public async Task<MatchSet<PlayerMatch>> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var matchSet = _useCache
                ? Cache.Get<MatchSet<PlayerMatch>>(uri)
                : null;

            if (matchSet == null)
            {
                matchSet = await session.Get<MatchSet<PlayerMatch>>(uri);

                Cache.AddStats(uri, matchSet);
            }

            return matchSet;
        }

        public virtual string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/players/{Player}/matches");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}