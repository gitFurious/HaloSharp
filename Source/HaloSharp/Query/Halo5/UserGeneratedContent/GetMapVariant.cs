using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;
using System;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    public class GetMapVariant : Query<MapVariant>
    {
        public override string Uri => HaloUriBuilder.Build($"ugc/h5/players/{_player}/mapvariants/{_mapVariantId}");

        private readonly string _player;
        private readonly Guid _mapVariantId;

        public GetMapVariant(string gamertag, Guid mapVariantId)
        {
            _player = gamertag;
            _mapVariantId = mapVariantId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetMapVariant query requires a valid Gamertag to be set.");
            }

            if (!_mapVariantId.IsValid())
            {
                validationResult.Messages.Add("GetMapVariant query requires a Map Variant Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}