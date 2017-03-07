using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Stats.Lifetime
{
    public static class GetWarzoneServiceRecordValidator
    {
        public static void Validate(this GetWarzoneServiceRecord query)
        {
            var validationResult = new ValidationResult();

            if (query.Parameters.ContainsKey("players"))
            {
                var players = query.Parameters["players"].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetWarzoneServiceRecord query requires valid Gamertags (Players) to be set.");
                    }
                }
            }
            else
            {
                validationResult.Messages.Add("GetWarzoneServiceRecord query requires a Player to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}