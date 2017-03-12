using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Validation.Common;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Profile
{
    public class GetEmblemImage : ImageQuery
    {
        public override string Uri => HaloUriBuilder.Build($"profile/h5/profiles/{_player}/emblem", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string SizeParameter = "size";

        private readonly string _player;

        public GetEmblemImage(string gamertag)
        {
            _player = gamertag;
        }

        public GetEmblemImage Size(int size)
        {
            _parameters[SizeParameter] = size.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetEmblemImage query requires a valid Gamertag (Player) to be set.");
            }

            if (_parameters.ContainsKey(SizeParameter))
            {
                var validSizes = new List<int> { 95, 128, 190, 256, 512 };

                int size;
                var parsed = int.TryParse(_parameters[SizeParameter], out size);

                if (!parsed || !validSizes.Contains(size))
                {
                    validationResult.Messages.Add($"GetEmblemImage optional parameter '{SizeParameter}' is invalid: {size}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}