using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Halo5.Stats.Lifetime;

namespace HaloSharp.Query.Halo5.Stats.Lifetime
{
    public class GetCustomServiceRecord : IQuery<CustomServiceRecord>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetCustomServiceRecord(string gamertag)
        {
            Parameters["players"] = gamertag;
        }

        public GetCustomServiceRecord(IEnumerable<string> gamertags)
        {
            Parameters["players"] = string.Join(",", gamertags);
        }

        public GetCustomServiceRecord SkipCache()
        {
            _useCache = false;

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

        public virtual string GetConstructedUri()
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