using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Validation.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Requisition Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetRequisition : IQuery<Requisition>
    {
        internal readonly Guid RequisitionId;

        private bool _useCache = true;

        public GetRequisition(Guid requisitionId)
        {
            RequisitionId = requisitionId;
        }

        public GetRequisition SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<Requisition> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var requisition = _useCache
                ? Cache.Get<Requisition>(uri)
                : null;

            if (requisition == null)
            {
                requisition = await session.Get<Requisition>(uri);

                Cache.AddMetadata(uri, requisition);
            }

            return requisition;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/requisitions/{RequisitionId}");

            return builder.ToString();
        }
    }
}