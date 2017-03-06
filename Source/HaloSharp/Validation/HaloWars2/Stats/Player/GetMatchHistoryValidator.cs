using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.Player;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.HaloWars2.Stats.Player
{
    public static class GetMatchHistoryValidator
    {
        public static void Validate(this GetMatchHistory query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMatchHistory query requires a valid Gamertag (Player) to be set.");
            }

            if (query.Parameters.ContainsKey("matchType"))
            {
                var matchType = query.Parameters["matchType"];

                var defined = Enum.IsDefined(typeof(Enumeration.HaloWars2.MatchType), matchType);

                if (!defined)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter 'Match Type' is invalid: {matchType}.");
                }
            }

            if (query.Parameters.ContainsKey("start"))
            {
                int start;
                var parsed = int.TryParse(query.Parameters["start"], out start);

                if (!parsed || start < 0)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter 'Skip' is invalid: {start}.");
                }
            }

            if (query.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(query.Parameters["count"], out count);

                if (!parsed || count < 1 || count > 25)
                {
                    validationResult.Messages.Add($"GetMatchHistory optional parameter 'Take' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}