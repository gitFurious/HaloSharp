using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    /// <summary>
    ///     Construct a query to retrieve metadata about player created map variants.
    /// </summary>
    public class ListMapVariants : IQuery<MapVariantResult>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly string Player;

        private bool _useCache = true;

        public ListMapVariants(string gamertag)
        {
            Player = gamertag;
        }

        public ListMapVariants SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     When specified, this indicates what field should be used to sort the results as the primary sort order. 
        ///     When omitted, "modified" (descending) is the assumed primary sort order. Allowed sort fields are: name, 
        ///     description, accesibility, created, modified, bookmarkCount.
        /// </summary>
        /// <param name="sort">The field that should be used to sort the results as the primary sort order.</param>
        public ListMapVariants SortBy(Model.Enumeration.Halo5.UserGeneratedContentSort sort)
        {
            Parameters["sort"] = sort.ToString();

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the ordering that will be applied. When omitted, "desc" is assumed. 
        /// </summary>
        public ListMapVariants OrderByDescending()
        {
            Parameters["order"] = "desc";

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the ordering that will be applied. When omitted, "desc" is assumed. 
        /// </summary>
        public ListMapVariants OrderByAscending()
        {
            Parameters["order"] = "asc";

            return this;
        }

        /// <summary>
        ///     When specified, this indicates the starting index (0-based) for which the list of results will begin at.
        /// </summary>
        /// <param name="count">The starting index (0-based) for which the list of results will begin at.</param>
        public ListMapVariants Skip(int count)
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
        public ListMapVariants Take(int count)
        {
            Parameters["count"] = count.ToString();

            return this;
        }

        public async Task<MapVariantResult> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var mapVariantResult = _useCache
                ? Cache.Get<MapVariantResult>(uri)
                : null;

            if (mapVariantResult == null)
            {
                mapVariantResult = await session.Get<MapVariantResult>(uri);

                Cache.AddUserGeneratedContent(uri, mapVariantResult);
            }

            return mapVariantResult;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"ugc/h5/players/{Player}/mapvariants");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}