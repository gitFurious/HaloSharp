using HaloSharp.Model.Metadata;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetRequisition : IQuery<Requisition>
    {
        private const string CacheKey = "Requisitions";

        private bool _useCache = true;
        private string _id;

        public GetRequisition ForRequisitionId(Guid requisitionId)
        {
            _id = requisitionId.ToString();
            return this;
        }

        public GetRequisition SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<Requisition> ApplyTo(IHaloSession session)
        {
            var requisition = _useCache
                ? Cache.Get<Requisition>($"{CacheKey}-{_id}")
                : null;

            if (requisition != null)
            {
                return requisition;
            }

            requisition = await session.Get<Requisition>(MakeUrl());

            Cache.Add($"{CacheKey}-{_id}", requisition);

            return requisition;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/requisitions/{_id}");

            return builder.ToString();
        }
    }
}
