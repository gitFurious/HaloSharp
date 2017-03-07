using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    public class GetCustomMatchDetails : IQuery<CustomMatch>
    {
        internal readonly Guid MatchId;

        private bool _useCache = true;

        public GetCustomMatchDetails(Guid matchId)
        {
            MatchId = matchId;
        }

        public GetCustomMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }
       
        public async Task<CustomMatch> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var match = _useCache
                ? Cache.Get<CustomMatch>(uri)
                : null;

            if (match == null)
            {
                match = await session.Get<CustomMatch>(uri);

                Cache.AddStats(uri, match);
            }

            return match;
        }

        public virtual string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/custom/matches/{MatchId}");

            return builder.ToString();
        }
    }
}