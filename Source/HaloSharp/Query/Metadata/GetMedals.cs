using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Medal Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetMedals : IQuery<List<Medal>>
    {
        private const string CacheKey = "Medals";

        private bool _useCache = true;

        public GetMedals SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Medal>> ApplyTo(IHaloSession session)
        {
            var medals = _useCache
                ? Cache.Get<List<Medal>>(CacheKey)
                : null;

            if (medals != null)
            {
                return medals;
            }

            medals = await session.Get<List<Medal>>(GetConstructedUri());

            Cache.Add(CacheKey, medals);

            return medals;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/medals");

            return builder.ToString();
        }
    }
}
