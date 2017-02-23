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
    public class GetCustomServiceRecord : IQuery<CustomServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetCustomServiceRecord SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     A player's gamertag.
        /// </summary>
        /// <param name="gamertag">Player's gamertag.</param>
        public GetCustomServiceRecord ForPlayer(string gamertag)
        {
            Parameters["players"] = gamertag;
            return this;
        }

        /// <summary>
        ///     A list of player gamertags. The number of concurrent supported player identifiers for this API is 1-32.
        /// </summary>
        /// <param name="gamertags">Player's gamertag(s).</param>
        public GetCustomServiceRecord ForPlayers(List<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
            return this;
        }

        public async Task<CustomServiceRecord> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var serviceRecord = _useCache
                ? Cache.Get<CustomServiceRecord>(uri)
                : null;

            if (serviceRecord == null)
            {
                serviceRecord = await session.Get<CustomServiceRecord>(uri);

                Cache.AddStats(uri, serviceRecord);
            }

            return serviceRecord;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/custom");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}