using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.Halo5.Stats
{
    
    class GetSpartanCompany : Query<SpartanCompany>
    {
        protected virtual string Path => $"stats/h5/companies/{_companyId}";

        public override string Uri => HaloUriBuilder.Build(Path);

        private readonly Guid _companyId;

        public GetSpartanCompany(Guid companyId)
        {
            _companyId = companyId;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_companyId.IsValid())
            {
                validationResult.Messages.Add("GetSpartanyCompany query requires a valid company Id to be set.");
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
