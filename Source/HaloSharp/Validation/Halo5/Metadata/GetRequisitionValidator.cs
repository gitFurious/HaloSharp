using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Metadata;

namespace HaloSharp.Validation.Halo5.Metadata
{
    public static class GetRequisitionValidator
    {
        public static void Validate(this GetRequisition getRequisition)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getRequisition.Id))
            {
                validationResult.Messages.Add("GetRequisition query requires a RequisitionId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
