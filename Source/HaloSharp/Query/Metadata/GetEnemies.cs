using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Enemy Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetEnemies : IQuery<List<Enemy>>
    {
        private const string CacheKey = "Enemies";

        private bool _useCache = true;

        public GetEnemies SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Enemy>> ApplyTo(IHaloSession session)
        {
            var enemies = _useCache
                ? Cache.Get<List<Enemy>>(CacheKey)
                : null;

            if (enemies != null)
            {
                return enemies;
            }

            enemies = await session.Get<List<Enemy>>(GetConstructedUri());

            Cache.Add(CacheKey, enemies);

            return enemies;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/enemies");

            return builder.ToString();
        }
    }
}