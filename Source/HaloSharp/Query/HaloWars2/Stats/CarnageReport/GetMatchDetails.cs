using System;
using System.Threading.Tasks;
using HaloSharp.Model.HaloWars2.Stats.CarnageReport;
using HaloSharp.Validation.HaloWars2.Stats.CarnageReport;

namespace HaloSharp.Query.HaloWars2.Stats.CarnageReport
{
    public class GetMatchDetails : IQuery<Match>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetMatchDetails(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<Match> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<Match>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<Match>(uri);

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
