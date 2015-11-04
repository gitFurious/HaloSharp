using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetImpulses : IQuery<List<Impulse>>
    {
        private const string CacheKey = "Impulses";

        private bool _useCache = true;

        public GetImpulses SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Impulse>> ApplyTo(IHaloSession session)
        {
            var impulses = _useCache
                ? Cache.Get<List<Impulse>>(CacheKey)
                : null;

            if (impulses != null)
            {
                return impulses;
            }

            impulses = await session.Get<List<Impulse>>(MakeUrl());

            Cache.Add(CacheKey, impulses);

            return impulses;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/impulses");

            return builder.ToString();
        }
    }
}
