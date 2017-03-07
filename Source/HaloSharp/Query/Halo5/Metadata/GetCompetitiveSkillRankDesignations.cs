using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetCompetitiveSkillRankDesignations : IQuery<List<CompetitiveSkillRankDesignation>>
    {
        private bool _useCache = true;

        public GetCompetitiveSkillRankDesignations SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<CompetitiveSkillRankDesignation>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var competitiveSkillRankDesignations = _useCache
                ? Cache.Get<List<CompetitiveSkillRankDesignation>>(uri)
                : null;

            if (competitiveSkillRankDesignations == null)
            {
                competitiveSkillRankDesignations = await session.Get<List<CompetitiveSkillRankDesignation>>(uri);

                Cache.AddMetadata(uri, competitiveSkillRankDesignations);
            }

            return competitiveSkillRankDesignations;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/csr-designations");

            return builder.ToString();
        }
    }
}