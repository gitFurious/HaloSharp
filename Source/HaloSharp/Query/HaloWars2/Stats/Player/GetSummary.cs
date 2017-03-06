using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Validation.HaloWars2.Stats.Player;
using System.Threading.Tasks;

namespace HaloSharp.Query.HaloWars2.Stats.Player
{
    public class GetSummary : IQuery<PlayerSummary>
    {
        internal readonly string Player;

        private bool _useCache = true;

        public GetSummary(string player)
        {
            Player = player;
        }

        public GetSummary SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<PlayerSummary> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<PlayerSummary>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<PlayerSummary>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            return $"stats/hw2/players/{Player}/stats";
        }
    }
}
