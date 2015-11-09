using HaloSharp.Model.Metadata;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetMapVariant : IQuery<MapVariant>
    {
        private const string CacheKey = "MapVariant";

        private bool _useCache = true;
        private string _id;

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

            mapVariant = await session.Get<MapVariant>(MakeUrl());

            Cache.Add($"{CacheKey}-{_id}", mapVariant);

            return mapVariant;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/map-variants/{_id}");

            return builder.ToString();
        }
    }
}
