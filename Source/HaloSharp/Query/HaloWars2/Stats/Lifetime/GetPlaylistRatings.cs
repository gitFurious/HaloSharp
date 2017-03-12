using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetPlaylistRatings : Query<PlaylistSummaryResultSet>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/hw2/playlist/{_playlistId}/rating", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string PlayersParameter = "players";

        private readonly Guid _playlistId;

        public GetPlaylistRatings(string player, Guid playlistId)
        {
            _parameters[PlayersParameter] = player;
            _playlistId = playlistId;
        }

        public GetPlaylistRatings(IEnumerable<string> players, Guid playlistId)
        {
            _parameters[PlayersParameter] = string.Join(",", players);
            _playlistId = playlistId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_parameters.ContainsKey(PlayersParameter))
            {
                var players = _parameters[PlayersParameter].Split(',');

                foreach (var player in players)
                {
                    if (!player.IsValidGamertag())
                    {
                        validationResult.Messages.Add("GetPlaylistRatings query requires a valid Gamertag to be set.");
                    }
                }
            }

            if (!_playlistId.IsValid())
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
