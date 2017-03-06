using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.HaloWars2.Stats.Player;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.HaloWars2.Stats.Player
{
    public static class GetPlaylistRatingsValidator
    {
        public static void Validate(this GetPlaylistRatings query)
        {
            var validationResult = new ValidationResult();

            if (query.Parameters.ContainsKey("players"))
            {
                var players = query.Parameters["players"].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetPlaylistRatings query requires a valid Gamertag (Player) to be set.");
                    }
                }
            }

            if (query.PlaylistId == default(Guid))
            {
                validationResult.Messages.Add("GetPlaylistRatings query requires a valid Playlist Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}