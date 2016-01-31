using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats.Lifetime;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Stats.Lifetime
{
    public static class GetArenaServiceRecordValidator
    {
        public static void Validate(this GetArenaServiceRecord getArenaServiceRecord)
        {
            var validationResult = new ValidationResult();

            if (getArenaServiceRecord.Parameters.ContainsKey("players"))
            {
                var players = getArenaServiceRecord.Parameters["players"].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetArenaServiceRecord query requires valid Gamertags (Players) to be set.");
                    }
                }
            }
            else
            {
                validationResult.Messages.Add("GetArenaServiceRecord query requires a Player to be set.");
            }



            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}