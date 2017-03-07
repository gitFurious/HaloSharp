using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Halo5.Stats.Lifetime;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    /// <summary>
    ///     Construct a query to retrieve players' Service Records. A Service Record contains a player's lifetime
    ///     statistics in the game mode.
    /// </summary>
    public class GetArenaServiceRecord : IQuery<ArenaServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetArenaServiceRecord(string gamertag)
        {
            Parameters["players"] = gamertag;
        }

        public GetArenaServiceRecord(IEnumerable<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
        }

        public GetArenaServiceRecord SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the Guid of the season to request the Arena Playlist Stats for.
        /// </summary>
        /// <param name="seasonId">The ID that uniquely identifies a season.</param>
        public GetArenaServiceRecord ForSeasonId(Guid seasonId)
        {
            Parameters["seasonId"] = seasonId.ToString();

            return this;
        }

        public async Task<ArenaServiceRecord> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var serviceRecord = _useCache
                ? Cache.Get<ArenaServiceRecord>(uri)
                : null;

            if (serviceRecord == null)
            {
                serviceRecord = await session.Get<ArenaServiceRecord>(uri);

                Cache.AddStats(uri, serviceRecord);
            }

            return serviceRecord;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/arena");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}