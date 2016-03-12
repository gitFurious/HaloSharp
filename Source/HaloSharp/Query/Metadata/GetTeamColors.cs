using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Team Color Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetTeamColors : IQuery<List<TeamColor>>
    {
        private bool _useCache = true;

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/team-colors");

            return builder.ToString();
        }

        public GetTeamColors SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<TeamColor>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var teamColors = _useCache
                ? Cache.Get<List<TeamColor>>(uri)
                : null;

            if (teamColors == null)
            {
                teamColors = await session.Get<List<TeamColor>>(uri);

                Cache.AddMetadata(uri, teamColors);
            }

            return teamColors;
        }
    }
}
