using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;
using System;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    public class GetGameVariant : Query<GameVariant>
    {
        public override string Uri => HaloUriBuilder.Build($"ugc/h5/players/{_player}/gamevariants/{_gameVariantId}");

        private readonly string _player;
        private readonly Guid _gameVariantId;

        public GetGameVariant(string gamertag, Guid gameVariantId)
        {
            _player = gamertag;
            _gameVariantId = gameVariantId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetGameVariant query requires a valid Gamertag to be set.");
            }

            if (!_gameVariantId.IsValid())
            {
                validationResult.Messages.Add("GetGameVariant query requires a Game Variant Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}