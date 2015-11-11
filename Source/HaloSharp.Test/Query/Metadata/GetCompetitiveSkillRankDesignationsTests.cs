using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetCompetitiveSkillRankDesignationsTests : TestSessionSetup
    {
        [Test]
        public async Task GetCompetitiveSkillRankDesignations()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<CompetitiveSkillRankDesignation>), result);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_IsSerializable()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<CompetitiveSkillRankDesignation>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}