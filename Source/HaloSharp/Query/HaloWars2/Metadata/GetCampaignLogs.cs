using HaloSharp.Model.HaloWars2.Metadata;
using HaloSharp.Validation.HaloWars2.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.HaloWars2.Metadata
{
    public class GetCampaignLogs : IQuery<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();

        private bool _useCache = true;

        public GetCampaignLogs Skip(int count)
        {
            Parameters["startAt"] = count.ToString();

            return this;
        }

        public GetCampaignLogs SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var response = _useCache
                ? Cache.Get<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>>(uri)
                : null;

            if (response == null)
            {
                response = await session.Get<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>>(uri);

                Cache.AddMetadata(uri, response);
            }

            return response;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/hw2/campaign-logs");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}
