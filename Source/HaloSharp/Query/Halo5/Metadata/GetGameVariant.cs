using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata;
using System;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetGameVariant : Query<GameVariant>
    {
        public override string Uri => HaloUriBuilder.Build($"metadata/h5/metadata/game-variants/{_gameVariantId}");

        private readonly Guid _gameVariantId;

        public GetGameVariant(Guid gameVariantId)
        {
            _gameVariantId = gameVariantId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (_gameVariantId == default(Guid))
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