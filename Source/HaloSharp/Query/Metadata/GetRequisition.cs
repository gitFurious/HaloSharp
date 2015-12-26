using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    public class GetRequisition : IQuery<Requisition>
    {
        private const string CacheKey = "Requisition";

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

            requisition = await session.Get<Requisition>(GetConstructedUri());

            Cache.Add($"{CacheKey}-{_id}", requisition);

            return requisition;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/requisitions/{_id}");

            return builder.ToString();
        }
    }
}
