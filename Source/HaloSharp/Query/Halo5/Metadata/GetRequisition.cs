using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata;
using System;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetRequisition : Query<Requisition>
    {
        public override string Uri => HaloUriBuilder.Build($"metadata/h5/metadata/requisitions/{_requisitionId}");

        private readonly Guid _requisitionId;

        public GetRequisition(Guid requisitionId)
        {
            _requisitionId = requisitionId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_requisitionId.IsValid())
            {
                validationResult.Messages.Add("GetRequisition query requires a Requisition Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}