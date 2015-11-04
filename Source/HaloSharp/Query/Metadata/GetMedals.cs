using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
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

            medals = await session.Get<List<Medal>>(MakeUrl());

            Cache.Add(CacheKey, medals);

            return medals;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/medals");

            return builder.ToString();
        }
    }
}
