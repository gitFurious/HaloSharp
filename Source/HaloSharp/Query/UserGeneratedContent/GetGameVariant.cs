using HaloSharp.Validation.UserGeneratedContent;
using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.UserGeneratedContent;

namespace HaloSharp.Query.UserGeneratedContent
{
    /// <summary>
    ///     Construct a query to retrieve metadata about player created game variants.
    /// </summary>
    public class GetGameVariant : IQuery<GameVariant>
    {
        private bool _useCache = true;
        internal string Player;
        internal string Id;

        public GetGameVariant SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The gamertag of the player that owns the game variant.
        /// </summary>
        /// <param name="gamertag">The gamertag of the player that owns the game variant.</param>
        public GetGameVariant ForPlayer(string gamertag)
        {
            Player = gamertag;

            return this;
        }

        /// <summary>
        ///     The ID for the game variant.
        /// </summary>
        /// <param name="gameVariantId">The ID for the game variant.</param>
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
            var builder = new StringBuilder($"ugc/h5/players/{Player}/gamevariants/{Id}");

            return builder.ToString();
        }
    }
}