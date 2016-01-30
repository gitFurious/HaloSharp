using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Metadata;

namespace HaloSharp.Validation.Metadata
{
    public static class GetGameVariantValidator
    {
        public static void Validate(this GetGameVariant getGameVariant)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getGameVariant.Id))
            {
                validationResult.Messages.Add("GetGameVariant query requires a GameVariantId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
