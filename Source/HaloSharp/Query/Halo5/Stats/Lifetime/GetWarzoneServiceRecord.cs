using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Halo5.Stats.Lifetime;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    public class GetWarzoneServiceRecord : IQuery<WarzoneServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetWarzoneServiceRecord(string gamertag)
        {
            Parameters["players"] = gamertag;
        }

        public GetWarzoneServiceRecord(IEnumerable<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
        }

        public GetWarzoneServiceRecord SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<WarzoneServiceRecord> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var serviceRecord = _useCache
                ? Cache.Get<WarzoneServiceRecord>(uri)
                : null;

            if (serviceRecord == null)
            {
                serviceRecord = await session.Get<WarzoneServiceRecord>(uri);

                Cache.AddStats(uri, serviceRecord);
            }

            return serviceRecord;
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