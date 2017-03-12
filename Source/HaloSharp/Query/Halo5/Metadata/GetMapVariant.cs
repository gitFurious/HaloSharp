using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata;
using System;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetMapVariant : Query<MapVariant>
    {
        public override string Uri => HaloUriBuilder.Build($"metadata/h5/metadata/map-variants/{_mapVariantId}");

        private readonly Guid _mapVariantId;

        public GetMapVariant(Guid mapVariantId)
        {
            _mapVariantId = mapVariantId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_mapVariantId == default(Guid))
            {
                validationResult.Messages.Add("GetMapVariant query requires a Map Variant Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}