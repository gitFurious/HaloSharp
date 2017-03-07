using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetWarzoneMatchDetails : IQuery<WarzoneMatch>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetWarzoneMatchDetails(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetWarzoneMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<WarzoneMatch> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var match = _useCache
                ? Cache.Get<WarzoneMatch>(uri)
                : null;

            if (match == null)
            {
                match = await session.Get<WarzoneMatch>(uri);

                Cache.AddStats(uri, match);
            }

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/warzone/matches/{MatchId}");

            return builder.ToString();
        }
    }
}