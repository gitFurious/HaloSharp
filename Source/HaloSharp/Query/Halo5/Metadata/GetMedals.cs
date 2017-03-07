using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetMedals : IQuery<List<Medal>>
    {
        private bool _useCache = true;

        public GetMedals SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Medal>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var medals = _useCache
                ? Cache.Get<List<Medal>>(uri)
                : null;

            if (medals == null)
            {
                medals = await session.Get<List<Medal>>(uri);

                Cache.AddMetadata(uri, medals);
            }

            return medals;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/medals");

            return builder.ToString();
        }
    }
}