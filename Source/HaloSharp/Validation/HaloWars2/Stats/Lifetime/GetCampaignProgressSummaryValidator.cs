using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.HaloWars2.Stats.Lifetime
{
    public static class GetCampaignProgressSummaryValidator
    {
        public static void Validate(this GetCampaignSummary query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetCampaignProgressSummary query requires a valid Gamertag (Player) to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}