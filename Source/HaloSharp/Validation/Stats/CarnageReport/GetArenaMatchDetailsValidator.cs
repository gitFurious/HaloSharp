using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.CarnageReport;

namespace HaloSharp.Validation.Stats.CarnageReport
{
    public static class GetArenaMatchDetailsValidator
    {
        public static void Validate(this GetArenaMatchDetails getArenaMatchDetails)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getArenaMatchDetails.MatchId))
            {
                validationResult.Messages.Add("GetArenaMatchDetails query requires a MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}