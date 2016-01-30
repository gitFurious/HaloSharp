using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.Lifetime;
using HaloSharp.Validation.Stats.Lifetime;

namespace HaloSharp.Query.Stats.Lifetime
{
    /// <summary>
    ///     Construct a query to retrieve players' Service Records. A Service Record contains a player's lifetime
    ///     statistics in the game mode.
    /// </summary>
    public class GetWarzoneServiceRecord : IQuery<WarzoneServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        /// <summary>
        ///     A player's gamertag.
        /// </summary>
        /// <param name="gamertag">Player's gamertag.</param>
        public GetWarzoneServiceRecord ForPlayer(string gamertag)
        {
            Parameters["players"] = gamertag;
            return this;
        }

        /// <summary>
        ///     A list of player gamertags. The number of concurrent supported player identifiers for this API is 1-32.
        /// </summary>
        /// <param name="gamertags">Player's gamertag(s).</param>
        public GetWarzoneServiceRecord ForPlayers(List<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
            return this;
        }

        public async Task<WarzoneServiceRecord> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var match = await session.Get<WarzoneServiceRecord>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/warzone");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}