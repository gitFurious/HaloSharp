using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Impulse Metadata. Use them to translate IDs from other APIs.
    /// </summary>
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

            impulses = await session.Get<List<Impulse>>(GetConstructedUri());

            Cache.Add(CacheKey, impulses);

            return impulses;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/impulses");

            return builder.ToString();
        }
    }
}