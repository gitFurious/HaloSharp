using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.UserGeneratedContent
{
    public static class GetMapVariantValidator
    {
        public static void Validate(this GetMapVariant GetMapVariant)
        {
            var validationResult = new ValidationResult();

            if (!GetMapVariant.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMapVariant query requires a valid Gamertag (Player) to be set.");
            }

            if (string.IsNullOrWhiteSpace(GetMapVariant.Id))
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
