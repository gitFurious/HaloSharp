using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;
using HaloSharp.Validation.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Requisition Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetRequisition : IQuery<Requisition>
    {
        private bool _useCache = true;
        internal string Id;

        public GetRequisition SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     An ID that uniquely identifies a Requisition.
        /// </summary>
        /// <param name="requisitionId">An ID that uniquely identifies a Requisition.</param>
        public GetRequisition ForRequisitionId(Guid requisitionId)
        {
            Id = requisitionId.ToString();

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
            var builder = new StringBuilder($"metadata/h5/metadata/requisitions/{Id}");

            return builder.ToString();
        }
    }
}