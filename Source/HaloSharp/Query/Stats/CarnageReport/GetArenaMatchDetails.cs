using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Validation.Stats.CarnageReport;

namespace HaloSharp.Query.Stats.CarnageReport
{
    /// <summary>
    ///     Construct a query to retrieve detailed statistics for a match. Some match details are available while the match is
    ///     in-progress, but  the behavior for incomplete matches in undefined.
    /// </summary>
    public class GetArenaMatchDetails : IQuery<ArenaMatch>
    {
        internal string MatchId;

        /// <summary>
        ///     An ID that uniquely identifies a match. Match IDs can be retrieved from the "GET Matches for Player" API.
        /// </summary>
        /// <param name="matchId">The ID that uniquely identifies a match.</param>
        public GetArenaMatchDetails ForMatchId(Guid matchId)
        {
            MatchId = matchId.ToString();

            return this;
        }

        public async Task<ArenaMatch> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var match = await session.Get<ArenaMatch>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/arena/matches/{MatchId}");

            return builder.ToString();
        }
    }
}