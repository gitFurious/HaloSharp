using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetCommendations : IQuery<List<Commendation>>
    {
        private bool _useCache = true;

        public GetCommendations SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Commendation>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var commendations = _useCache
                ? Cache.Get<List<Commendation>>(uri)
                : null;

            if (commendations == null)
            {
                commendations = await session.Get<List<Commendation>>(uri);

                Cache.AddMetadata(uri, commendations);
            }

            return commendations;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/commendations");

            return builder.ToString();
        }
    }
}