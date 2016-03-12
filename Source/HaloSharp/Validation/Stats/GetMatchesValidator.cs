using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Stats;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Stats
{
    public static class GetMatchesValidator
    {
        public static void Validate(this GetMatches getMatches)
        {
            var validationResult = new ValidationResult();

            if (!getMatches.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMatches query requires a valid Gamertag (Player) to be set.");
            }

            if (getMatches.Parameters.ContainsKey("modes"))
            {
                var modes = getMatches.Parameters["modes"].Split(',');

                foreach (var mode in modes)
                {
                    var defined = Enum.IsDefined(typeof (Enumeration.GameMode), mode);

                    if (!defined)
                    {
                        validationResult.Messages.Add($"GetMatches optional parameter 'Game Mode' is invalid: {mode}.");
                    }
                }
            }

            if (getMatches.Parameters.ContainsKey("start"))
            {
                int start;
                var parsed = int.TryParse(getMatches.Parameters["start"], out start);

                if (!parsed || start < 0)
                {
                    validationResult.Messages.Add($"GetMatches optional parameter 'Take' is invalid: {start}.");
                }
            }

            if (getMatches.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(getMatches.Parameters["count"], out count);

                if (!parsed || count < 1 || count > 25)
                {
                    validationResult.Messages.Add($"GetMatches optional parameter 'Take' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}