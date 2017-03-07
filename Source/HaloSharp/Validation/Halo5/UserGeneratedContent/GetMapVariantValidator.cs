using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.UserGeneratedContent
{
    public static class GetMapVariantValidator
    {
        public static void Validate(this GetMapVariant query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMapVariant query requires a valid Gamertag (Player) to be set.");
            }

            if (query.MapVariantId == default(Guid))
            {
                validationResult.Messages.Add("GetMapVariant query requires a Map Variant (Id) to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
