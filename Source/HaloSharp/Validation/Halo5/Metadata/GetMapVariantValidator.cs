using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Metadata;

namespace HaloSharp.Validation.Halo5.Metadata
{
    public static class GetMapVariantValidator
    {
        public static void Validate(this GetMapVariant query)
        {
            var validationResult = new ValidationResult();

            if (query.MapVariantId == default(Guid))
            {
                validationResult.Messages.Add("GetMapVariant query requires a MapVariantId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
