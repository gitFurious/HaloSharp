using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.UserGeneratedContent
{
    public static class GetGameVariantValidator
    {
        public static void Validate(this GetGameVariant getGameVariant)
        {
            var validationResult = new ValidationResult();

            if (!getGameVariant.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetGameVariant query requires a valid Gamertag (Player) to be set.");
            }

            if (string.IsNullOrWhiteSpace(getGameVariant.Id))
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
