using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata.Common;

namespace HaloSharp.Query.Metadata
{
    public class GetRequisitionPack : IQuery<RequisitionPack>
    {
        private const string CacheKey = "RequisitionPack";

        private bool _useCache = true;
        private string _id;

        public GetRequisitionPack ForRequisitionPackId(Guid requisitionPackId)
        {
            _id = requisitionPackId.ToString();
            return this;
        }

        public GetRequisitionPack SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<RequisitionPack> ApplyTo(IHaloSession session)
        {
            var requisitionPack = _useCache
                ? Cache.Get<RequisitionPack>($"{CacheKey}-{_id}")
                : null;

            if (requisitionPack != null)
            {
                return requisitionPack;
            }

            requisitionPack = await session.Get<RequisitionPack>(GetConstructedUri());

            Cache.Add(CacheKey, requisitionPack);

            return requisitionPack;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/requisition-packs/{_id}");

            return builder.ToString();
        }
    }
}
