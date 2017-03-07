using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetArenaMatchDetails : IQuery<ArenaMatch>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetArenaMatchDetails(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetArenaMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<ArenaMatch> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var match = _useCache
                ? Cache.Get<ArenaMatch>(uri)
                : null;

            if (match == null)
            {
                match = await session.Get<ArenaMatch>(uri);

                Cache.AddStats(uri, match);
            }

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/arena/matches/{MatchId}");

            return builder.ToString();
        }
    }
}