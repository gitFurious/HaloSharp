﻿using HaloSharp.Model.HaloWars2.Metadata;
using HaloSharp.Validation.HaloWars2.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.HaloWars2.Metadata
{
    public class GetDifficulties : IQuery<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetDifficulties Skip(int count)
        {
            Parameters["startAt"] = count.ToString();

            return this;
        }

        public GetDifficulties SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>>(uri);

                Cache.AddMetadata(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/hw2/difficulties");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}
