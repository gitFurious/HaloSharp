using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Profile
{
    class GetPlayerAppearance : Query<PlayerAppearance>
    {
        protected virtual string Path => $"profile/h5/profiles/{_player}/appearance";

        public override string Uri => HaloUriBuilder.Build(Path);

        private readonly string _player;

        public GetPlayerAppearance(string gamertag)
        {
            _player = gamertag;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if(!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetPlayerAppearance query requires a valid Gamertag (Player) to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }

    }
}
