using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.CarnageReport;

namespace HaloSharp.Validation.Stats.CarnageReport
{
    public static class GetMatchEventsValidator
    {
        public static void Validate(this GetMatchEvents getMatchEvents)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getMatchEvents.MatchId))
            {
                validationResult.Messages.Add("GetMatchEvents query requires a MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}