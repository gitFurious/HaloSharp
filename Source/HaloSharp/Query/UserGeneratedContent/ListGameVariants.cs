using HaloSharp.Model.UserGeneratedContent;
using HaloSharp.Validation.UserGeneratedContent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.UserGeneratedContent
{
    /// <summary>
    ///     Construct a query to retrieve metadata about player created game variants.
    /// </summary>
    public class ListGameVariants : IQuery<GameVariantResult>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal string Player;

        private bool _useCache = true;

        public ListGameVariants SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The gamertag of the player that owns the listed game variants.
        /// </summary>
        /// <param name="gamertag">The gamertag of the player that owns the listed game variants.</param>
        public ListGameVariants ForPlayer(string gamertag)
        {
            Player = gamertag;

            return this;
        }

        /// <summary>
        ///     When specified, this indicates what field should be used to sort the results as the primary sort order. 
        ///     When omitted, "modified" (descending) is the assumed primary sort order. Allowed sort fields are: name, 
        ///     description, accesibility, created, modified, bookmarkCount.
        /// </summary>
        /// <param name="sort">The field that should be used to sort the results as the primary sort order.</param>
        public ListGameVariants SortBy(Model.Enumeration.UserGeneratedContentSort sort)
        {
            Parameters["sort"] = sort.ToString();

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the ordering that will be applied. When omitted, "desc" is assumed. 
        /// </summary>
        public ListGameVariants OrderByDescending()
        {
            Parameters["order"] = "desc";

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the ordering that will be applied. When omitted, "desc" is assumed. 
        /// </summary>
        public ListGameVariants OrderByAscending()
        {
            Parameters["order"] = "asc";

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the starting index (0-based) for which the list of results will begin at.
        /// </summary>
        /// <param name="count">The starting index (0-based) for which the list of results will begin at.</param>
        public ListGameVariants Skip(int count)
        {
            Parameters["start"] = count.ToString();

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the maximum quantity of items the client would like returned in the
        ///     response. When the value is greater than the allowed range [1,100], the maximum allowed value is used
        ///     instead. The "Count" field in the response will confirm the actual value that was used.
        /// </summary>
        /// <param name="count">The maximum quantity of items the client would like returned.</param>
        public ListGameVariants Take(int count)
        {
            Parameters["count"] = count.ToString();

            return this;
        }

        public async Task<GameVariantResult> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var gameVariantResult = _useCache
                ? Cache.Get<GameVariantResult>(uri)
                : null;

            if (gameVariantResult == null)
            {
                gameVariantResult = await session.Get<GameVariantResult>(uri);

                Cache.AddMetadata(uri, gameVariantResult);
            }

            return gameVariantResult;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"ugc/h5/players/{Player}/gamevariants");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}