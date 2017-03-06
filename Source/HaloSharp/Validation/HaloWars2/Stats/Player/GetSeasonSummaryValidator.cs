using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.Player;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.HaloWars2.Stats.Player
{
    public static class GetSeasonSummaryValidator
    {
        public static void Validate(this GetSeasonSummary query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetSeasonSummary query requires a valid Gamertag (Player) to be set.");
            }

            if (query.SeasonId == default(Guid))
            {
                validationResult.Messages.Add("GetSeasonSummary query requires a valid Season Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}