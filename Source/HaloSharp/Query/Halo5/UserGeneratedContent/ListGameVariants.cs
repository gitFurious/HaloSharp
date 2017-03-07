using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    public class ListGameVariants : IQuery<GameVariantResult>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly string Player;

        private bool _useCache = true;

        public ListGameVariants(string gamertag)
        {
            Player = gamertag;
        }

        public ListGameVariants SkipCache()
        {
            _useCache = false;

            return this;
        }

        public ListGameVariants SortBy(Model.Enumeration.Halo5.UserGeneratedContentSort sort)
        {
            Parameters["sort"] = sort.ToString();

            return this;
        }

        public ListGameVariants OrderByDescending()
        {
            Parameters["order"] = "desc";

            return this;
        }

        public ListGameVariants OrderByAscending()
        {
            Parameters["order"] = "asc";

            return this;
        }

        public ListGameVariants Skip(int count)
        {
            Parameters["start"] = count.ToString();

            return this;
        }

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

                Cache.AddUserGeneratedContent(uri, gameVariantResult);
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