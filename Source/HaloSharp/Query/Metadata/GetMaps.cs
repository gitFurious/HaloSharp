using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Map Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetMaps : IQuery<List<Map>>
    {
        private const string CacheKey = "Maps";

        private bool _useCache = true;

        public GetMaps SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Map>> ApplyTo(IHaloSession session)
        {
            var maps = _useCache
                ? Cache.Get<List<Map>>(CacheKey)
                : null;

            if (maps != null)
            {
                return maps;
            }

            maps = await session.Get<List<Map>>(GetConstructedUri());

            Cache.Add(CacheKey, maps);

            return maps;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/maps");

            return builder.ToString();
        }
    }
}
