using HaloSharp.Model.Metadata;
using HaloSharp.Validation.Metadata;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Map Variant Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetMapVariant : IQuery<MapVariant>
    {
        private const string CacheKey = "MapVariant";

        private bool _useCache = true;
        internal string Id;

        public GetMapVariant SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a Map Variant..
        /// </summary>
        /// <param name="mapVariantId">An ID that uniquely identifies a Map Variant.</param>
        public GetMapVariant ForMapVariantId(Guid mapVariantId)
        {
            Id = mapVariantId.ToString();

            return this;
        }

        public async Task<MapVariant> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var mapVariant = _useCache
                ? Cache.Get<MapVariant>($"{CacheKey}-{Id}")
                : null;

            if (mapVariant != null)
            {
                return mapVariant;
            }

            mapVariant = await session.Get<MapVariant>(GetConstructedUri());

            Cache.Add($"{CacheKey}-{Id}", mapVariant);

            return mapVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/map-variants/{Id}");

            return builder.ToString();
        }
    }
}