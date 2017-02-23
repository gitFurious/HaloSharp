using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    /// <summary>
    ///     Construct a query to retrieve metadata about player created map variants.
    /// </summary>
    public class GetMapVariant : IQuery<MapVariant>
    {
        private bool _useCache = true;
        internal string Player;
        internal string Id;

        public GetMapVariant SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The gamertag of the player that owns the map variant.
        /// </summary>
        /// <param name="gamertag">The gamertag of the player that owns the map variant.</param>
        public GetMapVariant ForPlayer(string gamertag)
        {
            Player = gamertag;

            return this;
        }

        /// <summary>
        ///     The ID for the map variant.
        /// </summary>
        /// <param name="mapVariantId">The ID for the map variant.</param>
        public GetMapVariant ForMapVariantId(Guid mapVariantId)
        {
            Id = mapVariantId.ToString();

            return this;
        }

        public async Task<MapVariant> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var mapVariant = _useCache
                ? Cache.Get<MapVariant>(uri)
                : null;

            if (mapVariant == null)
            {
                mapVariant = await session.Get<MapVariant>(uri);

                Cache.AddUserGeneratedContent(uri, mapVariant);
            }

            return mapVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"ugc/h5/players/{Player}/mapvariants/{Id}");

            return builder.ToString();
        }
    }
}