using HaloSharp.Model.Metadata.Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetRequisitionPacks : IQuery<List<RequisitionPack>>
    {
        private const string CacheKey = "RequisitionPacks";

        private bool _useCache = true;

        public GetRequisitionPacks SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<RequisitionPack>> ApplyTo(IHaloSession session)
        {
            var requisitionPacks = _useCache
                ? Cache.Get<List<RequisitionPack>>(CacheKey)
                : null;

            if (requisitionPacks != null)
            {
                return requisitionPacks;
            }

            requisitionPacks = await session.Get<List<RequisitionPack>>(MakeUrl());

            Cache.Add(CacheKey, requisitionPacks);

            return requisitionPacks;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/requisition-packs");

            return builder.ToString();
        }
    }
}
