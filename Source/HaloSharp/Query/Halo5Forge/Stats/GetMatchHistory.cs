
namespace HaloSharp.Query.Halo5Forge.Stats
{
    public class GetMatchHistory : Halo5.Stats.GetMatchHistory
    {
        protected override string Path => $"stats/h5pc/players/{_player}/matches";

        private readonly string _player;

        public GetMatchHistory(string gamertag) : base(gamertag)
        {
            _player = gamertag;
        }
    }
}