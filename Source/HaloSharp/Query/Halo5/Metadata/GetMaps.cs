using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Map Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetMaps : IQuery<List<Map>>
    {
        private bool _useCache = true;

        public GetMaps SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Map>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var maps = _useCache
                ? Cache.Get<List<Map>>(uri)
                : null;

            if (maps == null)
            {
                maps = await session.Get<List<Map>>(uri);

                Cache.AddMetadata(uri, maps);
            }

            return maps;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/maps");

            return builder.ToString();
        }
    }
}