using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetTeamColors : IQuery<List<TeamColor>>
    {
        private const string CacheKey = "TeamColors";

        private bool _useCache = true;

        public GetTeamColors SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<TeamColor>> ApplyTo(IHaloSession session)
        {
            var teamColors = _useCache
                ? Cache.Get<List<TeamColor>>(CacheKey)
                : null;

            if (teamColors != null)
            {
                return teamColors;
            }

            teamColors = await session.Get<List<TeamColor>>(GetConstructedUri());

            Cache.Add(CacheKey, teamColors);

            return teamColors;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/team-colors");

            return builder.ToString();
        }
    }
}
