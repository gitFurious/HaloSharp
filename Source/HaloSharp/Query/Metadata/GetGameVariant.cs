using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;
using HaloSharp.Validation.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Game Variant Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetGameVariant : IQuery<GameVariant>
    {
        private bool _useCache = true;
        internal string Id;

        public GetGameVariant SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a Game Variant.
        /// </summary>
        /// <param name="gameVariantId">An ID that uniquely identifies a Game Variant.</param>
        public GetGameVariant ForGameVariantId(Guid gameVariantId)
        {
            Id = gameVariantId.ToString();

            return this;
        }

        public async Task<GameVariant> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var gameVariant = _useCache
                ? Cache.Get<GameVariant>(uri)
                : null;

            if (gameVariant == null)
            {
                gameVariant = await session.Get<GameVariant>(uri);

                Cache.AddMetadata(uri, gameVariant);
            }

            return gameVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/game-variants/{Id}");

            return builder.ToString();
        }
    }
}