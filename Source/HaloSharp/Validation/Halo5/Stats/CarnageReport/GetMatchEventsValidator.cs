using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats.CarnageReport;

namespace HaloSharp.Validation.Halo5.Stats.CarnageReport
{
    public static class GetMatchEventsValidator
    {
        public static void Validate(this GetMatchEvents query)
        {
            var validationResult = new ValidationResult();

            if (query.MatchId == default(Guid))
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