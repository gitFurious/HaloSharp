using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Season Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetSeasons : IQuery<List<Season>>
    {
        private const string CacheKey = "Seasons";

        private bool _useCache = true;

        public GetSeasons SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Season>> ApplyTo(IHaloSession session)
        {
            var seasons = _useCache
                ? Cache.Get<List<Season>>(CacheKey)
                : null;

            if (seasons != null)
            {
                return seasons;
            }

            seasons = await session.Get<List<Season>>(GetConstructedUri());

            Cache.Add(CacheKey, seasons);

            return seasons;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/seasons");

            return builder.ToString();
        }
    }
}