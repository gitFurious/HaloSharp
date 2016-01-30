using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.CarnageReport;

namespace HaloSharp.Validation.Stats.CarnageReport
{
    public static class GetCampaignMatchDetailsValidator
    {
        public static void Validate(this GetCampaignMatchDetails getCampaignMatchDetails)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(getCampaignMatchDetails.MatchId))
            {
                validationResult.Messages.Add("GetCampaignMatchDetails query requires a MatchId to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}