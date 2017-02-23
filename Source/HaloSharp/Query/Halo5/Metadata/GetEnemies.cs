using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Enemy Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetEnemies : IQuery<List<Enemy>>
    {
        private bool _useCache = true;

        public GetEnemies SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Enemy>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var enemies = _useCache
                ? Cache.Get<List<Enemy>>(uri)
                : null;

            if (enemies == null)
            {
                enemies = await session.Get<List<Enemy>>(uri);

                Cache.AddMetadata(uri, enemies);
            }

            return enemies;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/enemies");

            return builder.ToString();
        }
    }
}