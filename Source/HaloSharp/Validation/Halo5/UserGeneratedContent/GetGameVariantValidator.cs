using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.UserGeneratedContent
{
    public static class GetGameVariantValidator
    {
        public static void Validate(this GetGameVariant query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetGameVariant query requires a valid Gamertag (Player) to be set.");
            }

            if (query.GameVariantId== default(Guid))
            {
                validationResult.Messages.Add("GetGameVariant query requires a Game Variant (Id) to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
