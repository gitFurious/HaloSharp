using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    /// <summary>
    ///     Construct a query to retrieve detailed statistics for a match. Some match details are available while the match
    ///     is in-progress, but the behavior for incomplete matches in undefined.
    /// </summary>
    public class GetCustomMatchDetails : IQuery<CustomMatch>
    {
        internal string MatchId;

        private bool _useCache = true;

        public GetCustomMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a match. Match IDs can be retrieved from the "GET Matches for Player" API.
        /// </summary>
        /// <param name="matchId">The ID that uniquely identifies a match.</param>
        public GetCustomMatchDetails ForMatchId(Guid matchId)
        {
            MatchId = matchId.ToString();

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

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/custom/matches/{MatchId}");

            return builder.ToString();
        }
    }
}