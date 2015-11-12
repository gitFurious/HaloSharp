using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetSkulls : IQuery<List<Skull>>
    {
        private const string CacheKey = "Skulls";

        private bool _useCache = true;

        public GetSkulls SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Skull>> ApplyTo(IHaloSession session)
        {
            var skulls = _useCache
                ? Cache.Get<List<Skull>>(CacheKey)
                : null;

            if (skulls != null)
            {
                return skulls;
            }

            skulls = await session.Get<List<Skull>>(GetConstructedUri());

            Cache.Add(CacheKey, skulls);

            return skulls;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/skulls");

            return builder.ToString();
        }
    }
}
