using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats;
using System;
using System.Collections.Generic;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Stats
{
    public class GetLeaderboard : Query<Leaderboard>
    {
        public override string Uri => HaloUriBuilder.Build($"stats/h5/player-leaderboards/csr/{_seasonId}/{_playlistId}", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string CountParameter = "count";

        private readonly Guid _playlistId;
        private readonly Guid _seasonId;

        public GetLeaderboard(Guid seasonId, Guid playlistId)
        {
            _seasonId = seasonId;
            _playlistId = playlistId;
        }

        public GetLeaderboard Take(int count)
        {
            _parameters[CountParameter] = count.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_seasonId.IsValid())
            {
                validationResult.Messages.Add("GetLeaderboard query requires a Season Id to be set.");
            }

            if (!_playlistId.IsValid())
            {
                validationResult.Messages.Add("GetLeaderboard query requires a Playlist Id to be set.");
            }

            if (_parameters.ContainsKey(CountParameter))
            {
                int take;
                var parsed = int.TryParse(_parameters[CountParameter], out take);

                if (!parsed || !take.IsValidTake())
                {
                    validationResult.Messages.Add($"GetLeaderboard optional parameter '{CountParameter}' is invalid: {take}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}