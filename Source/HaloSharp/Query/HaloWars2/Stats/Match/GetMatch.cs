using HaloSharp.Validation.HaloWars2.Stats.Match;
using System;
using System.Threading.Tasks;

namespace HaloSharp.Query.HaloWars2.Stats.Match
{
    public class GetMatch : IQuery<Model.HaloWars2.Stats.Match>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetMatch(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetMatch SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<Model.HaloWars2.Stats.Match> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<Model.HaloWars2.Stats.Match>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<Model.HaloWars2.Stats.Match>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            return $"stats/hw2/matches/{MatchId}";
        }
    }
}
