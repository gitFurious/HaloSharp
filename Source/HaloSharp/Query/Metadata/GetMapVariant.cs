using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    /// Construct a query to retrieve detailed Map Variant Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetMapVariant : IQuery<MapVariant>
    {
        private const string CacheKey = "MapVariant";

        private bool _useCache = true;
        private string _id;

        /// <summary>
        /// An ID that uniquely identifies a Map Variant..
        /// </summary>
        /// <param name="mapVariantId">An ID that uniquely identifies a Map Variant.</param>
        public GetMapVariant ForMapVariantId(Guid mapVariantId)
        {
            _id = mapVariantId.ToString();
            return this;
        }

        public GetMapVariant SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<MapVariant> ApplyTo(IHaloSession session)
        {
            var mapVariant = _useCache
                ? Cache.Get<MapVariant>($"{CacheKey}-{_id}")
                : null;

            if (mapVariant != null)
            {
                return mapVariant;
            }

            mapVariant = await session.Get<MapVariant>(GetConstructedUri());

            Cache.Add($"{CacheKey}-{_id}", mapVariant);

            return mapVariant;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/map-variants/{_id}");

            return builder.ToString();
        }
    }
}
