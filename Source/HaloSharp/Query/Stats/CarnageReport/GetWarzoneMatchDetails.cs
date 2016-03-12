using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Validation.Stats.CarnageReport;

namespace HaloSharp.Query.Stats.CarnageReport
{
    /// <summary>
    ///     Construct a query to retrieve detailed statistics for a match. Some match details are available while the match
    ///     is in-progress, but  the behavior for incomplete matches in undefined.
    /// </summary>
    public class GetWarzoneMatchDetails : IQuery<WarzoneMatch>
    {
        internal string MatchId;

        private bool _useCache = true;

        public GetWarzoneMatchDetails SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a match. Match IDs can be retrieved from the "GET Matches for Player" API.
        /// </summary>
        /// <param name="matchId">The ID that uniquely identifies a match.</param>
        public GetWarzoneMatchDetails ForMatchId(Guid matchId)
        {
            MatchId = matchId.ToString();

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