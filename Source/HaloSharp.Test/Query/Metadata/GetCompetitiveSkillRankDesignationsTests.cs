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
    public class GetCompetitiveSkillRankDesignationsTests
    {
        private const string BaseUri = "metadata/h5/metadata/csr-designations";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCompetitiveSkillRankDesignations();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<CompetitiveSkillRankDesignation>), result);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_IsSerializable()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<CompetitiveSkillRankDesignation>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}