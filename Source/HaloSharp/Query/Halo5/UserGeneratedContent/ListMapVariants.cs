using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Halo5.UserGeneratedContent;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
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

        public ListMapVariants SortBy(Model.Enumeration.Halo5.UserGeneratedContentSort sort)
        {
            Parameters["sort"] = sort.ToString();

            return this;
        }

        public ListMapVariants OrderByDescending()
        {
            Parameters["order"] = "desc";

            return this;
        }

        public ListMapVariants OrderByAscending()
        {
            Parameters["order"] = "asc";

            return this;
        }

        public ListMapVariants Skip(int count)
        {
            Parameters["start"] = count.ToString();

            return this;
        }

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