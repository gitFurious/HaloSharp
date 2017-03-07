using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.HaloWars2.Stats.Lifetime;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetExperienceSummary : IQuery<ExperienceSummaryResultSet>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetExperienceSummary(string player)
        {
            Parameters["players"] = player;
        }

        public GetExperienceSummary(IEnumerable<string> players)
        {
            Parameters["players"] = string.Join(",", players);
        }

        public GetExperienceSummary SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<ExperienceSummaryResultSet> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<ExperienceSummaryResultSet>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<ExperienceSummaryResultSet>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/hw2/xp");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}
