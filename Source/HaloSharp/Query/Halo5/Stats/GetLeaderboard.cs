using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Validation.Halo5.Stats;

namespace HaloSharp.Query.Halo5.Stats
{
    /// <summary>
    ///     Construct a query to retrieve the player leaderboard. The leaderboard consists of the top players for a playlist in
    ///     a season
    /// </summary>
    public class GetLeaderboard : IQuery<Leaderboard>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;
        internal string PlaylistId;
        internal string SeasonId;

        public GetLeaderboard SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The ID for the season.
        /// </summary>
        /// <param name="seasonId">The ID that uniquely identifies a season.</param>
        public GetLeaderboard ForSeasonId(Guid seasonId)
        {
            SeasonId = seasonId.ToString();

            return this;
        }

        /// <summary>
        ///     The ID for the playlist.
        /// </summary>
        /// <param name="playlistId">The ID that uniquely identifies a playlist.</param>
        public GetLeaderboard ForPlaylistId(Guid playlistId)
        {
            PlaylistId = playlistId.ToString();

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the maximum quantity of items the client would like returned in the response. When
        ///     omitted, 200 is assumed. When the value contains a non-digit or is exactly "0", HTTP 400 ("Bad Request") is
        ///     returned. When the value is greater than the allowed range [1,250], the maximum allowed value is used instead. The
        ///     "Count" field in the response will confirm the actual value that was used.
        /// </summary>
        /// <param name="count">The maximum quantity of items the client would like returned.</param>
        public GetLeaderboard Take(int count)
        {
            Parameters["count"] = count.ToString();

            return this;
        }

        public async Task<Leaderboard> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var leaderboard = _useCache
                ? Cache.Get<Leaderboard>(uri)
                : null;

            if (leaderboard == null)
            {
                leaderboard = await session.Get<Leaderboard>(uri);

                Cache.AddStats(uri, leaderboard);
            }

            return leaderboard;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/player-leaderboards/csr/{SeasonId}/{PlaylistId}");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}