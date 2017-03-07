using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.CarnageReport;

namespace HaloSharp.Validation.HaloWars2.Stats.CarnageReport
{
    public static class GetMatchValidator
    {
        public static void Validate(this GetMatchDetails query)
        {
            var validationResult = new ValidationResult();

            if (query.MatchId == default(Guid))
            {
                validationResult.Messages.Add("GetMatch query requires a valid MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}