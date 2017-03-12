using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata.Common;
using System;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetRequisitionPack : Query<RequisitionPack>
    {
        public override string Uri => HaloUriBuilder.Build($"metadata/h5/metadata/requisition-packs/{_requisitionPackId}");

        private readonly Guid _requisitionPackId;

        public GetRequisitionPack(Guid requisitionPackId)
        {
            _requisitionPackId = requisitionPackId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_requisitionPackId.IsValid())
            {
                validationResult.Messages.Add("GetRequisitionPack query requires a Requisition Pack Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}