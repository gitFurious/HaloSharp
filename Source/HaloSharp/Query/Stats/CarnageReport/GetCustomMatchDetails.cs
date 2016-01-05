using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Stats.CarnageReport;

namespace HaloSharp.Query.Stats.CarnageReport
{
    /// <summary>
    /// Construct a query to retrieve detailed statistics for a match. Some match details are available while the match 
    /// is in-progress, but the behavior for incomplete matches in undefined.
    /// </summary>
    public class GetCustomMatchDetails : IQuery<CustomMatch>
    {
        private string _matchId;

        /// <summary>
        /// An ID that uniquely identifies a match. Match IDs can be retrieved from the "GET Matches for Player" API.
        /// </summary>
        /// <param name="matchId">The ID that uniquely identifies a match.</param>
        public GetCustomMatchDetails ForMatchId(Guid matchId)
        {
            _matchId = matchId.ToString();
            return this;
        }

        public async Task<CustomMatch> ApplyTo(IHaloSession session)
        {
            var match = await session.Get<CustomMatch>(GetConstructedUri());

            return match;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5/custom/matches/{_matchId}");

            return builder.ToString();
        }
    }
}