using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
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

            enemies = await session.Get<List<Enemy>>(MakeUrl());

            Cache.Add(CacheKey, enemies);

            return enemies;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/enemies");

            return builder.ToString();
        }
    }
}
