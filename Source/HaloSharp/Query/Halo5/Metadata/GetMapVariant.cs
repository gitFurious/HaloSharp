using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Validation.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetMapVariant : IQuery<MapVariant>
    {
        internal readonly Guid MapVariantId;

        private bool _useCache = true;

        public GetMapVariant(Guid mapVariantId)
        {
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

                Cache.AddMetadata(uri, mapVariant);
            }

            return mapVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/map-variants/{MapVariantId}");

            return builder.ToString();
        }
    }
}