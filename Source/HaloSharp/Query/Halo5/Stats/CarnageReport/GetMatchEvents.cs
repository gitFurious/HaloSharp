using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Validation.Halo5.Stats.CarnageReport;

namespace HaloSharp.Query.Halo5.Stats.CarnageReport
{
    /// <summary>
    ///     Construct a query to retrieve a set of events related to the match specified. The set of events will grow over time
    ///     as data becomes available. Events are only available once the match has completed. This endpoint does not have the
    ///     accuracy guarantees that other APIs have so use with caution. This endpoint may not return matches before December
    ///     1st 2015
    /// </summary>
    public class GetMatchEvents : IQuery<MatchEventSummary>
    {
        private bool _useCache = true;
        internal string MatchId;

        public GetMatchEvents SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a match. Match IDs can be retrieved from the "GET Matches for Player" API.
        /// </summary>
        /// <param name="matchId">The ID that uniquely identifies a match.</param>
        public GetMatchEvents ForMatchId(Guid matchId)
        {
            MatchId = matchId.ToString();

            return this;
        }

        public async Task<MatchEventSummary> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var match = _useCache
                ? Cache.Get<MatchEventSummary>(uri)
                : null;

            if (match == null)
            {
                match = await session.Get<MatchEventSummary>(uri);

                Cache.AddStats(uri, match);
            }

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/matches/{MatchId}/events");

            return builder.ToString();
        }
    }
}