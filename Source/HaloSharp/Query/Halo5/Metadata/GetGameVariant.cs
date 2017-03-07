using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Validation.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetGameVariant : IQuery<GameVariant>
    {
        internal readonly Guid GameVariantId;

        private bool _useCache = true;

        public GetGameVariant(Guid gameVariantId)
        {
            GameVariantId = gameVariantId;
        }

        public GetGameVariant SkipCache()
        {
            _useCache = false;

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
            var builder = new StringBuilder($"metadata/h5/metadata/game-variants/{GameVariantId}");

            return builder.ToString();
        }
    }
}