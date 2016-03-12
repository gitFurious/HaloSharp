using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Game Base Variant Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetGameBaseVariants : IQuery<List<GameBaseVariant>>
    {
        private bool _useCache = true;

        public GetGameBaseVariants SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<GameBaseVariant>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var gameBaseVariants = _useCache
                ? Cache.Get<List<GameBaseVariant>>(uri)
                : null;

            if (gameBaseVariants == null)
            {
                gameBaseVariants = await session.Get<List<GameBaseVariant>>(uri);

                Cache.AddMetadata(uri, gameBaseVariants);
            }

            return gameBaseVariants;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/game-base-variants");

            return builder.ToString();
        }
    }
}