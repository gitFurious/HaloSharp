using System;
using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Validation.HaloWars2.Stats.Lifetime;

namespace HaloSharp.Query.HaloWars2.Stats.Lifetime
{
    public class GetSeasonSummary : IQuery<SeasonSummary>
    {
        internal readonly string Player;
        internal readonly Guid SeasonId;

        private bool _useCache = true;

        public GetSeasonSummary(string player, Guid seasonId)
        {
            Player = player;
            SeasonId = seasonId;
        }

        public GetSeasonSummary SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<SeasonSummary> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<SeasonSummary>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<SeasonSummary>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            return $"stats/hw2/players/{Player}/stats/seasons/{SeasonId}";
        }
    }
}
