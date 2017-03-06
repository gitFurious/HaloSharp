using System;
using HaloSharp.Exception;
using HaloSharp.Model;

namespace HaloSharp.Validation.HaloWars2.Stats.Match
{
    public static class GetMatchEventsValidator
    {
        public static void Validate(this Query.HaloWars2.Stats.Match.GetMatchEvents query)
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