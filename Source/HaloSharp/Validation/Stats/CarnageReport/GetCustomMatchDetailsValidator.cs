using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.CarnageReport;

namespace HaloSharp.Validation.Stats.CarnageReport
{
    public static class GetCustomMatchDetailsValidator
    {
        public static void Validate(this GetCustomMatchDetails getCustomMatchDetails)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getCustomMatchDetails.MatchId))
            {
                validationResult.Messages.Add("GetCustomMatchDetails query requires a MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}