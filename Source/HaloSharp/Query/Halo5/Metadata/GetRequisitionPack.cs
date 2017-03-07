using System;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata.Common;
using HaloSharp.Validation.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Requisition Pack Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetRequisitionPack : IQuery<RequisitionPack>
    {
        internal readonly Guid RequisitionPackId;

        private bool _useCache = true;

        public GetRequisitionPack(Guid requisitionPackId)
        {
            RequisitionPackId = requisitionPackId;
        }

        public GetRequisitionPack SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<RequisitionPack> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var requisitionPack = _useCache
                ? Cache.Get<RequisitionPack>(uri)
                : null;

            if (requisitionPack == null)
            {
                requisitionPack = await session.Get<RequisitionPack>(uri);

                Cache.AddMetadata(uri, requisitionPack);
            }

            return requisitionPack;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"metadata/h5/metadata/requisition-packs/{RequisitionPackId}");

            return builder.ToString();
        }
    }
}