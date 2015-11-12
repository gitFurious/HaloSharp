using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetCommendations : IQuery<List<Commendation>>
    {
        private const string CacheKey = "Commendations";

        private bool _useCache = true;

        public GetCommendations SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Commendation>> ApplyTo(IHaloSession session)
        {
            var commendations = _useCache
                ? Cache.Get<List<Commendation>>(CacheKey)
                : null;

            if (commendations != null)
            {
                return commendations;
            }

            commendations = await session.Get<List<Commendation>>(GetConstructedUri());

            Cache.Add(CacheKey, commendations);

            return commendations;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/commendations");

            return builder.ToString();
        }
    }
}
