using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Stats.Lifetime
{
    public static class GetCampaignServiceRecordValidator
    {
        public static void Validate(this GetCampaignServiceRecord getCampaignServiceRecord)
        {
            var validationResult = new ValidationResult();

            if (getCampaignServiceRecord.Parameters.ContainsKey("players"))
            {
                var players = getCampaignServiceRecord.Parameters["players"].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetCampaignServiceRecord query requires valid Gamertags (Players) to be set.");
                    }
                }
            }
            else
            {
                validationResult.Messages.Add("GetCampaignServiceRecord query requires a Player to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}