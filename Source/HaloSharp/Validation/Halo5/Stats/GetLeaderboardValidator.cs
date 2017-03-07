using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Stats;

namespace HaloSharp.Validation.Halo5.Stats
{
    public static class GetLeaderboardValidator
    {
        public static void Validate(this GetLeaderboard query)
        {
            var validationResult = new ValidationResult();

            if (query.SeasonId == default(Guid))
            {
                validationResult.Messages.Add("GetLeaderboard query requires a SeasonId to be set.");
            }

            if (query.PlaylistId == default(Guid))
            {
                validationResult.Messages.Add("GetLeaderboard query requires a PlaylistId to be set.");
            }

            if (query.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(query.Parameters["count"], out count);

                if (!parsed || count < 1 || count > 250)
                {
                    validationResult.Messages.Add($"GetLeaderboard optional parameter 'Take' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}