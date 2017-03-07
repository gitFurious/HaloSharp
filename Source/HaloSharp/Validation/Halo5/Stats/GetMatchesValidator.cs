using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Stats
{
    public static class GetMatchesValidator
    {
        public static void Validate(this GetMatchHistory query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMatches query requires a valid Gamertag (Player) to be set.");
            }

            if (query.Parameters.ContainsKey("modes"))
            {
                var modes = query.Parameters["modes"].Split(',');

                foreach (var mode in modes)
                {
                    var defined = Enum.IsDefined(typeof (Enumeration.Halo5.GameMode), mode);

                    if (!defined)
                    {
                        validationResult.Messages.Add($"GetMatches optional parameter 'Game Mode' is invalid: {mode}.");
                    }
                }
            }

            if (query.Parameters.ContainsKey("start"))
            {
                int start;
                var parsed = int.TryParse(query.Parameters["start"], out start);

                if (!parsed || start < 0)
                {
                    validationResult.Messages.Add($"GetMatches optional parameter 'Take' is invalid: {start}.");
                }
            }

            if (query.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(query.Parameters["count"], out count);

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