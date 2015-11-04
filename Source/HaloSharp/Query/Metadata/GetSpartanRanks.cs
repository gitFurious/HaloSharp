using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
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

            spartanRanks = await session.Get<List<SpartanRank>>(MakeUrl());

            Cache.Add(CacheKey, spartanRanks);

            return spartanRanks;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/spartan-ranks");

            return builder.ToString();
        }
    }
}
