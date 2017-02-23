using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Skull Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetSkulls : IQuery<List<Skull>>
    {
        private bool _useCache = true;

        public GetSkulls SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Skull>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var skulls = _useCache
                ? Cache.Get<List<Skull>>(uri)
                : null;

            if (skulls == null)
            {
                skulls = await session.Get<List<Skull>>(uri);

                Cache.AddMetadata(uri, skulls);
            }

            return skulls;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/skulls");

            return builder.ToString();
        }
    }
}