using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Metadata;

namespace HaloSharp.Validation.Metadata
{
    public static class GetMapVariantValidator
    {
        public static void Validate(this GetMapVariant getMapVariant)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getMapVariant.Id))
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
