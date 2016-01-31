using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.CarnageReport;

namespace HaloSharp.Validation.Stats.CarnageReport
{
    public static class GetWarzoneMatchDetailsValidator
    {
        public static void Validate(this GetWarzoneMatchDetails getWarzoneMatchDetails)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getWarzoneMatchDetails.MatchId))
            {
                validationResult.Messages.Add("GetWarzoneMatchDetails query requires a MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}