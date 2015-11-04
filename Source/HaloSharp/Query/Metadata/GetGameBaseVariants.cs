using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetGameBaseVariants : IQuery<List<GameBaseVariant>>
    {
        private const string CacheKey = "GameBaseVariants";

        private bool _useCache = true;

        public GetGameBaseVariants SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<GameBaseVariant>> ApplyTo(IHaloSession session)
        {
            var gameBaseVariants = _useCache
                ? Cache.Get<List<GameBaseVariant>>(CacheKey)
                : null;

            if (gameBaseVariants != null)
            {
                return gameBaseVariants;
            }

            gameBaseVariants = await session.Get<List<GameBaseVariant>>(MakeUrl());

            Cache.Add(CacheKey, gameBaseVariants);

            return gameBaseVariants;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/game-base-variants");

            return builder.ToString();
        }
    }
}
