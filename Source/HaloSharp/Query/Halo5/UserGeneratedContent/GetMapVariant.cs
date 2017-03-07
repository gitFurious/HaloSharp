using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    public class GetMapVariant : IQuery<MapVariant>
    {
        internal readonly string Player;
        internal readonly Guid MapVariantId;

        private bool _useCache = true;

        public GetMapVariant(string gamertag, Guid mapVariantId)
        {
            Player = gamertag;
            MapVariantId = mapVariantId;
        }

        public GetMapVariant SkipCache()
        {
            _useCache = false;

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
            var builder = new StringBuilder($"ugc/h5/players/{Player}/mapvariants/{MapVariantId}");

            return builder.ToString();
        }
    }
}