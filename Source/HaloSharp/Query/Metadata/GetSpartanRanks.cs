using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Spartan Rank Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetSpartanRanks : IQuery<List<SpartanRank>>
    {
        private const string CacheKey = "SpartanRanks";

        private bool _useCache = true;

        public GetSpartanRanks SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<SpartanRank>> ApplyTo(IHaloSession session)
        {
            var spartanRanks = _useCache
                ? Cache.Get<List<SpartanRank>>(CacheKey)
                : null;

            if (spartanRanks != null)
            {
                return spartanRanks;
            }

            spartanRanks = await session.Get<List<SpartanRank>>(GetConstructedUri());

            Cache.Add(CacheKey, spartanRanks);

            return spartanRanks;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/spartan-ranks");

            return builder.ToString();
        }
    }
}
