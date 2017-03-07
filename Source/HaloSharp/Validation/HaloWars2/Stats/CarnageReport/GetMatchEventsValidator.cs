using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.CarnageReport;

namespace HaloSharp.Validation.HaloWars2.Stats.CarnageReport
{
    public static class GetMatchEventsValidator
    {
        public static void Validate(this GetMatchEvents query)
        {
            var validationResult = new ValidationResult();

            if (query.MatchId == default(Guid))
            {
                validationResult.Messages.Add("GetMatchEvents query requires a valid MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}