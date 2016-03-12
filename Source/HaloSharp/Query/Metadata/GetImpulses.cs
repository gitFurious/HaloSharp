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
        private bool _useCache = true;

        public GetImpulses SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Impulse>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var impulses = _useCache
                ? Cache.Get<List<Impulse>>(uri)
                : null;

            if (impulses == null)
            {
                impulses = await session.Get<List<Impulse>>(uri);

                Cache.AddMetadata(uri, impulses);
            }

            return impulses;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/impulses");

            return builder.ToString();
        }
    }
}