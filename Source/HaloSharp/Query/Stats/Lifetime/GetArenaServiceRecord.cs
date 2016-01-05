using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.Lifetime;

namespace HaloSharp.Query.Stats.Lifetime
{
    /// <summary>
    /// Construct a query to retrieve players' Service Records. A Service Record contains a player's lifetime 
    /// statistics in the game mode.
    /// </summary>
    public class GetArenaServiceRecord : IQuery<ArenaServiceRecord>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        /// <summary>
        /// A player's gamertag.
        /// </summary>
        /// <param name="gamertag">Player's gamertag.</param>
        public GetArenaServiceRecord ForPlayer(string gamertag)
        {
            _parameters["players"] = gamertag;
            return this;
        }

        /// <summary>
        /// A list of player gamertags. The number of concurrent supported player identifiers for this API is 1-32.
        /// </summary>
        /// <param name="gamertags">Player's gamertag(s).</param>
        public GetArenaServiceRecord ForPlayers(List<string> gamertags)
        {
            _parameters["players"] = string.Join(",", gamertags);
            return this;
        }

        public async Task<ArenaServiceRecord> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<ArenaServiceRecord>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/arena");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}