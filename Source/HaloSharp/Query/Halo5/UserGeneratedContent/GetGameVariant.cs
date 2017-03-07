using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    /// <summary>
    ///     Construct a query to retrieve metadata about player created game variants.
    /// </summary>
    public class GetGameVariant : IQuery<GameVariant>
    {
        internal readonly string Player;
        internal readonly Guid GameVariantId;

        private bool _useCache = true;

        public GetGameVariant(string gamertag, Guid gameVariantId)
        {
            Player = gamertag;
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

                Cache.AddUserGeneratedContent(uri, gameVariant);
            }

            return gameVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"ugc/h5/players/{Player}/gamevariants/{GameVariantId}");

            return builder.ToString();
        }
    }
}