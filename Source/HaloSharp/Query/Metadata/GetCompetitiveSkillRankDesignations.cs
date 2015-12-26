using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    public class GetCompetitiveSkillRankDesignations : IQuery<List<CompetitiveSkillRankDesignation>>
    {
        private const string CacheKey = "CompetitiveSkillRankDesignations";

        private bool _useCache = true;

        public GetCompetitiveSkillRankDesignations SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<CompetitiveSkillRankDesignation>> ApplyTo(IHaloSession session)
        {
            var competitiveSkillRankDesignations = _useCache
                ? Cache.Get<List<CompetitiveSkillRankDesignation>>(CacheKey)
                : null;

            if (competitiveSkillRankDesignations != null)
            {
                return competitiveSkillRankDesignations;
            }

            competitiveSkillRankDesignations = await session.Get<List<CompetitiveSkillRankDesignation>>(GetConstructedUri());

            Cache.Add(CacheKey, competitiveSkillRankDesignations);

            return competitiveSkillRankDesignations;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/csr-designations");

            return builder.ToString();
        }
    }
}
