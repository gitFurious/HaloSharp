using System;
using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Model.HaloWars2.Stats.CarnageReport;
using HaloSharp.Validation.HaloWars2.Stats.CarnageReport;

namespace HaloSharp.Query.HaloWars2.Stats.CarnageReport
{
    public class GetMatchEvents : IQuery<MatchEventSummary>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetMatchEvents(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetMatchEvents SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<MatchEventSummary> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<MatchEventSummary>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<MatchEventSummary>(uri);

                Cache.AddStats(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            return $"stats/hw2/matches/{MatchId}/events";
        }
    }
}
