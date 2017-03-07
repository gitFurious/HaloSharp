using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.HaloWars2.Stats.Lifetime;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetPlaylistRatings : IQuery<PlaylistSummaryResultSet>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly Guid PlaylistId;

        private bool _useCache = true;

        public GetPlaylistRatings(string player, Guid playlistId)
        {
            Parameters["players"] = player;
            PlaylistId = playlistId;
        }

        public GetPlaylistRatings(IEnumerable<string> players, Guid playlistId)
        {
            Parameters["players"] = string.Join(",", players);
            PlaylistId = playlistId;
        }

        public GetPlaylistRatings SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<PlaylistSummaryResultSet> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<PlaylistSummaryResultSet>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<PlaylistSummaryResultSet>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/hw2/playlist/{PlaylistId}/rating");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}
