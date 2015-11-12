using HaloSharp.Model.Metadata;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetGameVariant : IQuery<GameVariant>
    {
        private const string CacheKey = "GameVariant";

        private bool _useCache = true;
        private string _id;

        public GetGameVariant ForGameVariantId(Guid gameVariantId)
        {
            _id = gameVariantId.ToString();
            return this;
        }

        public GetGameVariant SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<GameVariant> ApplyTo(IHaloSession session)
        {
            var gameVariant = _useCache
                ? Cache.Get<GameVariant>($"{CacheKey}-{_id}")
                : null;

            if (gameVariant != null)
            {
                return gameVariant;
            }

            gameVariant = await session.Get<GameVariant>(GetConstructedUri());

            Cache.Add($"{CacheKey}-{_id}", gameVariant);

            return gameVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/game-variants/{_id}");

            return builder.ToString();
        }
    }
}
