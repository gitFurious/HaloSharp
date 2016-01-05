using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Game Base Variant Metadata. Use them to translate IDs from other APIs.
    /// </summary>
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

            gameBaseVariants = await session.Get<List<GameBaseVariant>>(GetConstructedUri());

            Cache.Add(CacheKey, gameBaseVariants);

            return gameBaseVariants;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/game-base-variants");

            return builder.ToString();
        }
    }
}
