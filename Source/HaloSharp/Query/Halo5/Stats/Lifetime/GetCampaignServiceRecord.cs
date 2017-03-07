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
    public class GetCampaignServiceRecord : IQuery<CampaignServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetCampaignServiceRecord(string gamertag)
        {
            Parameters["players"] = gamertag;
        }

        public GetCampaignServiceRecord(IEnumerable<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
        }

        public GetCampaignServiceRecord SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<CampaignServiceRecord> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var serviceRecord = _useCache
                ? Cache.Get<CampaignServiceRecord>(uri)
                : null;

            if (serviceRecord == null)
            {
                serviceRecord = await session.Get<CampaignServiceRecord>(uri);

                Cache.AddStats(uri, serviceRecord);
            }

            return serviceRecord;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("stats/h5/servicerecords/campaign");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}