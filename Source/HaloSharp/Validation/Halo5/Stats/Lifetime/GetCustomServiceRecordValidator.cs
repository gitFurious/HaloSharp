using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Stats.Lifetime
{
    public static class GetCustomServiceRecordValidator
    {
        public static void Validate(this GetCustomServiceRecord getCustomServiceRecord)
        {
            var validationResult = new ValidationResult();

            if (getCustomServiceRecord.Parameters.ContainsKey("players"))
            {
                var players = getCustomServiceRecord.Parameters["players"].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetCustomServiceRecord query requires valid Gamertags (Players) to be set.");
                    }
                }
            }
            else
            {
                validationResult.Messages.Add("GetCustomServiceRecord query requires a Player to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
